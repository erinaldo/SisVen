package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Date;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class correlativos extends AppCompatActivity {

    private String lafechaactivacion;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.correlativos);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Correlativos (CAF)");
        actionbar.setSubtitle("M-03");

        final EditText valorinicial = (EditText) findViewById(R.id.xValorInicial);
        final EditText valorfinal = (EditText) findViewById(R.id.xValorFinal);
        final Spinner tiposdocs = (Spinner) findViewById(R.id.spinnertipo);
        final Button botonvolver = (Button) findViewById(R.id.bVolver);
        final Button botonguardar = (Button) findViewById(R.id.bGuardar);

        ArrayAdapter adapter = ArrayAdapter.createFromResource(this,R.array.tiposdoc,R.layout.spinner_item_grande);
        tiposdocs.setAdapter(adapter);

        final DatePicker dp = (DatePicker) findViewById(R.id.xFecha_Activacion);
        dp.setMaxDate(new Date().getTime());

        final String localusuario = ((variables_gloabales) this.getApplication()).getLocalUsuarioActual();
        final String rutusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();
        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();

        // Agrega el Correlativo
        botonguardar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                if (!verificaConexion(correlativos.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(correlativos.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
                final String eltipodoc = tiposdocs.getSelectedItem().toString();
                final String el_valorinicial = valorinicial.getText().toString();
                final String el_valorfinal = valorfinal.getText().toString();

                ////////// FORMATO A LA FECHA DEL DATAPICKER
                int   day  = dp.getDayOfMonth();
                int   month= dp.getMonth() + 1;
                int   year = dp.getYear();

                String xday = Integer.toString(day);
                String xmonth = Integer.toString(month);
                String xyear = Integer.toString(year);

                int largoxday = xday.length();
                int largoxmonth = xmonth.length();

                if (largoxmonth == 1){
                    if (largoxday == 1){
                        lafechaactivacion = "" + year + "-0" + month + "-0" + day;
                    }else{
                        lafechaactivacion = "" + year + "-0" + month + "-" + day;
                    }
                }else{
                    if (largoxday == 1){
                        lafechaactivacion = "" + year + "-" + month + "-0" + day;
                    }else{
                        lafechaactivacion = "" + year + "-" + month + "-" + day;
                    }
                }

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);

                            boolean success = jsonResponse.getBoolean("success");


                            if(success){
                                Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Correlativo Guardado Correctamente", Toast.LENGTH_SHORT);
                                mensajeconfirmacion.show();
                                Intent abrircaf = new Intent(correlativos.this, correlativos.class);
                                correlativos.this.startActivity(abrircaf);

                            }else{

                                ////////// manejo de situaciones
                                android.support.v7.app.AlertDialog.Builder builder = new android.support.v7.app.AlertDialog.Builder(correlativos.this);

                                builder.setMessage("Los Datos no Corresponden")
                                        .setNegativeButton("Reintentar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };

                respuesta_correlativo correlativosRequest = new respuesta_correlativo(localusuario, rutusuario, eltipodoc, lafechaactivacion, el_valorinicial, el_valorfinal, laidkey, elusuario, responselistener);
                RequestQueue queue = Volley.newRequestQueue(correlativos.this);
                queue.add(correlativosRequest);

            }


        });
        //Llama al activity de Menú
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenu = new Intent(correlativos.this,Menu.class);
                startActivity(abrirmenu);
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
