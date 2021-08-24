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
import android.widget.EditText;
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
 */

public class precio extends AppCompatActivity {
    private int elpreciodelarticulo;
    private int labarra1;
    private int labarra2;
    private int labarra3;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.precio);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Precios");
        actionbar.setSubtitle("M-04");

        final EditText EtCodigoArticulo = (EditText) findViewById(R.id.xCodigoArticulo);
        final EditText EtNombreArticulo = (EditText) findViewById(R.id.xNombreArticulo);
        final EditText EtBarra1 = (EditText) findViewById(R.id.xBarra1);
        final EditText EtBarra2 = (EditText) findViewById(R.id.xBarra2);
        final EditText EtBarra3 = (EditText) findViewById(R.id.xBarra3);
        final EditText EtPrecioArticulo = (EditText) findViewById(R.id.xPrecioArticulo);

        EtPrecioArticulo.addTextChangedListener(new NumberTextWatcher(EtPrecioArticulo));

        Button botonvolver = (Button) findViewById(R.id.bVolver);
        Button botonguardar = (Button) findViewById(R.id.bGuardar);

        //Llama al activity de Menú
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenu = new Intent(precio.this,Menu.class);
                startActivity(abrirmenu);
            }


        });

        final String rutdelusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();
        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();

        //  Registra Precios
        botonguardar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                if (!verificaConexion(precio.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(precio.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                final String elcodigodelarticulo = EtCodigoArticulo.getText().toString();
                final String elnombredelarticulo = EtNombreArticulo.getText().toString();
                final String labarra_1 = EtBarra1.getText().toString();
                final String labarra_2 = EtBarra2.getText().toString();
                final String labarra_3 = EtBarra3.getText().toString();

                final String elprecioo = EtPrecioArticulo.getText().toString();
                final String montoprecioformatonumerico = elprecioo.replace(".", "");

                elpreciodelarticulo = Integer.parseInt(montoprecioformatonumerico);


                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Artículo Registrado Correctamente", Toast.LENGTH_SHORT);
                                mensajeconfirmacion.show();
                                Intent abrirprecios = new Intent(precio.this, precio.class);
                                precio.this.startActivity(abrirprecios);
                            }else{
                                AlertDialog.Builder builder = new AlertDialog.Builder(precio.this);
                                builder.setMessage("Artículo ya se encuentra Registrado")
                                        .setNegativeButton("Reintentar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }


                    }
                };

                respuesta_precio preciosRequest = new respuesta_precio(elcodigodelarticulo, elnombredelarticulo, labarra_1, labarra_2, labarra_3, elpreciodelarticulo, laidkey, rutdelusuario, elusuario, responselistener);
                RequestQueue queue = Volley.newRequestQueue(precio.this);
                queue.add(preciosRequest);



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
}
