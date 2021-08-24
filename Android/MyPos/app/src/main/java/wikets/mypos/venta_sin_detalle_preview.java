package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Miguel on 03-05-2018.
 */

public class venta_sin_detalle_preview extends AppCompatActivity {
    private int ElMontodeLaBoletaa;
    private String ElMododelaBoleta;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.venta_sin_detalle_preview);

        setTitle("Confirmar Emisión");

        Button botonsi = (Button) findViewById(R.id.bSi);
        Button botonno = (Button) findViewById(R.id.bNo);

        final TextView MontoPreview = (TextView) findViewById(R.id.lMontoPreview);
        ///  final EditText MontodelaBoleta = (EditText) findViewById(R.id.xMontoBoleta);


        /// Cargar el monto de la boleta
        Intent obtenerextra = getIntent();
        Bundle extras = obtenerextra.getExtras();

        if (extras != null) {
            final String datomontoboleta = (String) extras.get("monto_boleta");
            final String elmodoboleta = (String) extras.get("modo");
            MontoPreview.setText("$ " + datomontoboleta);

            final String montoboletaformatonumerico = datomontoboleta.replace(".", "");

            ElMontodeLaBoletaa = Integer.parseInt(montoboletaformatonumerico);
            ElMododelaBoleta = elmodoboleta;
        }



        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();
        final String elrutusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();

        // Confirma la Venta
        botonsi.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                if (!verificaConexion(venta_sin_detalle_preview.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_sin_detalle_preview.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");
                            boolean caf = jsonResponse.getBoolean("caf");

                            if(success){

                                if(caf){
                                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_sin_detalle_preview.this);
                                    builder.setMessage("No hay CAF disponible")
                                            .setNegativeButton("Aceptar", null)
                                            .create()
                                            .show();
                                }else{

                                    Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Boleta Emitida Correctamente", Toast.LENGTH_SHORT);
                                    mensajeconfirmacion.show();

                                    String modopordefecto = "sin";

                                    if (ElMododelaBoleta.equals(modopordefecto)){
                                        Intent abrirmodo = new Intent(venta_sin_detalle_preview.this, venta_sin_detalle.class);
                                        venta_sin_detalle_preview.this.startActivity(abrirmodo);
                                    }else{
                                        Intent abrirmodo = new Intent(venta_sin_detalle_preview.this, venta_vuelto.class);
                                        venta_sin_detalle_preview.this.startActivity(abrirmodo);
                                    }
                                }


                            }else{

                                if(caf){
                                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_sin_detalle_preview.this);
                                    builder.setMessage("No hay CAF disponible")
                                            .setNegativeButton("Reintentar", null)
                                            .create()
                                            .show();
                                }else{
                                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_sin_detalle_preview.this);
                                    builder.setMessage("El Registro de la Boleta ha Fallado")
                                            .setNegativeButton("Reintentar", null)
                                            .create()
                                            .show();
                                }


                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }


                    }
                };

                respuesta_boleta_simple boletasimpleRequest = new respuesta_boleta_simple(ElMontodeLaBoletaa, laidkey, elusuario, elrutusuario, responselistener);
                RequestQueue queue = Volley.newRequestQueue(venta_sin_detalle_preview.this);
                queue.add(boletasimpleRequest);



            }


        });

        // Rechaza la Venta
        botonno.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                Toast mensajerechazo = Toast.makeText(getApplicationContext(), "Boleta Rechazada", Toast.LENGTH_SHORT);
                mensajerechazo.show();
                //MontodelaBoleta.setText("");
                Intent abrirventa = new Intent(venta_sin_detalle_preview.this,venta_sin_detalle.class);
                startActivity(abrirventa);
            }


        });

    }



    public static boolean verificaConexion(Context ctx) {
        boolean bConectado = false;
        ConnectivityManager connec = (ConnectivityManager) ctx
                .getSystemService(Context.CONNECTIVITY_SERVICE);
        // No sólo wifi, también GPRS
        NetworkInfo[] redes = connec.getAllNetworkInfo();
        // este bucle debería no ser tan ñapa
        for (int i = 0; i < 2; i++) {
            // ¿Tenemos conexión? ponemos a true
            if (redes[i].getState() == NetworkInfo.State.CONNECTED) {
                bConectado = true;
            }
        }
        return bConectado;
    }
}
