package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.graphics.Paint;
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

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.ParseException;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class venta_detallada_preview extends AppCompatActivity {

    private int elmontoneto;
    private int elmontoiva;
    private int elmontototal;

    private String eltipodeldoc;
    private String laformadelpago;
    private String elrutcliente;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.venta_detallada_preview);

        setTitle("Confirmar Emisión");

        Button botonsi = (Button) findViewById(R.id.bSi);
        Button botonno = (Button) findViewById(R.id.bNo);

        final TextView ElNeto = (TextView) findViewById(R.id.lnetopreview);
        final TextView ElIva = (TextView) findViewById(R.id.livapreview);
        final TextView ElTotal = (TextView) findViewById(R.id.ltotalpreview);

        ElIva.setPaintFlags(ElIva.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);

        /// Cargar el monto de la boleta
        Intent obtenerextra = getIntent();
        Bundle extras = obtenerextra.getExtras();

        if (extras != null) {
            final String montoneto = (String) extras.get("monto_neto");
            final String montoiva = (String) extras.get("monto_iva");
            final String montototal = (String) extras.get("monto_total");
            final String tipodoc = (String) extras.get("tipodoc");
            final String formapago = (String) extras.get("formapago");
            final String rutcliente = (String) extras.get("rutdelcliente");
            final Integer lacantidadarticulos = (Integer) extras.get("cantidadarticulos");

            ///// obtener los articulos por intent

            eltipodeldoc = tipodoc;
            laformadelpago = formapago;
            elrutcliente = rutcliente;

            final String montonetonumerico = formatodenumero(montoneto);
            final String montoivanumerico = formatodenumero(montoiva);
            final String montototalnumerico = formatodenumero(montototal);

            ElNeto.setText("NETO: $ " + montonetonumerico);
            ElIva.setText("IVA: $ " + montoivanumerico);
            ElTotal.setText("TOTAL: $ " + montototalnumerico);

            elmontoneto = Integer.parseInt(montoneto);
            elmontoiva = Integer.parseInt(montoiva);
            elmontototal = Integer.parseInt(montototal);
        }

        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();
        final String elrutusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();

        // Confirma la Venta con Detalle
        botonsi.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                if (!verificaConexion(venta_detallada_preview.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada_preview.this);
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
                                Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Documento Emitido Correctamente", Toast.LENGTH_SHORT);
                                mensajeconfirmacion.show();

                                Intent abrirdetalle = new Intent(venta_detallada_preview.this, venta_detallada.class);
                                venta_detallada_preview.this.startActivity(abrirdetalle);

                            }else{

                                if(caf){
                                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada_preview.this);
                                    builder.setMessage("No hay CAF disponible")
                                            .setNegativeButton("Reintentar", null)
                                            .create()
                                            .show();
                                }else{
                                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada_preview.this);
                                    builder.setMessage("El Registro del Documento ha Fallado")
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

                respuesta_boleta_detallada boletadetalleRequest = new respuesta_boleta_detallada(elmontoneto, elmontoiva, elmontototal, eltipodeldoc, laformadelpago, laidkey, elusuario, elrutusuario, elrutcliente, responselistener);
                RequestQueue queue = Volley.newRequestQueue(venta_detallada_preview.this);
                queue.add(boletadetalleRequest);





            }


        });

        // Rechaza la Venta con Detalle
        botonno.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                ////////////

                onBackPressed();  // Invoca al método Volver
            }


        });

    }


    public static String formatodenumero(String elnumero){

        DecimalFormat df;
        DecimalFormat dfnd;
        boolean hasFractionalPart;

        String resultado = "";

        DecimalFormatSymbols simbolos = new DecimalFormatSymbols();
        simbolos.setDecimalSeparator(',');
        simbolos.setGroupingSeparator('.');

        df = new DecimalFormat("#,###.##", simbolos);
        dfnd = new DecimalFormat("#,###", simbolos);
        hasFractionalPart = false;

        int inilen, endlen;
        inilen = elnumero.length();

        String v = elnumero.toString().replace(String.valueOf(df.getDecimalFormatSymbols().getGroupingSeparator()), "");
        Number n = null;
        try {
            n = df.parse(v);
        } catch (ParseException e) {
            e.printStackTrace();
        }

        if (hasFractionalPart) {
            /// setea valor
            elnumero = (df.format(n));
        } else {
            /// setea valor
            elnumero = (dfnd.format(n));
        }


        resultado = elnumero;

        return resultado;
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
