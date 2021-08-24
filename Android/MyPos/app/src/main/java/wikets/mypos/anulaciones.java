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
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;
import wikets.mypos.R;

import static wikets.mypos.R.layout.anulaciones;

/**
 * Created by Miguel on 04/05/2018.
 * */

public class anulaciones extends AppCompatActivity {


    private int ElNumeroDoc;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(anulaciones);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Anulaciones");
        actionbar.setSubtitle("M-02");

        final Spinner tipo = (Spinner) findViewById(R.id.spinnertipo);
        final Button botonvolver = (Button) findViewById(R.id.bVolver);
        final Button botonanular = (Button) findViewById(R.id.bAnular);

        final EditText NumeroAnular = (EditText) findViewById(R.id.xNumeroAnular);

        ArrayAdapter adapter = ArrayAdapter.createFromResource(this,R.array.tiposdoc,R.layout.spinner_item_grande);
        tipo.setAdapter(adapter);

        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();
        final String elrutusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();

        // ANULA EL DOCUMENTO
        botonanular.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                if (!verificaConexion(anulaciones.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(anulaciones.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
                String elnumeroaanular = NumeroAnular.getText().toString();

                if ( (elnumeroaanular == null) || (elnumeroaanular.isEmpty()) ) {
                    elnumeroaanular = "0";
                }

                ElNumeroDoc = Integer.parseInt(elnumeroaanular);
                final String eltipodoc = tipo.getSelectedItem().toString();

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);

                            boolean success = jsonResponse.getBoolean("success");
                            boolean existencia = jsonResponse.getBoolean("existencia");
                            boolean caf = jsonResponse.getBoolean("caf");

                            if(success){

                                if(caf){
                                    Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "No hay CAF Disponible", Toast.LENGTH_LONG);
                                    mensajeconfirmacion.show();

                                    Intent abrirprecios = new Intent(anulaciones.this, anulaciones.class);
                                    anulaciones.this.startActivity(abrirprecios);

                                }else{
                                    Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Documento Anulado Correctamente", Toast.LENGTH_SHORT);
                                    mensajeconfirmacion.show();
                                    Intent abrirprecios = new Intent(anulaciones.this, anulaciones.class);
                                    anulaciones.this.startActivity(abrirprecios);
                                }

                            }else{
                                AlertDialog.Builder builder = new AlertDialog.Builder(anulaciones.this);

                                if(existencia) {
                                    builder.setMessage("Documento ya esta Anulado")
                                            .setNegativeButton("Aceptar", null)
                                            .create()
                                            .show();
                                }else{builder.setMessage("Los Datos no Corresponden")
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


                respuesta_anulacion_documento anulaciondocumentoRequest = new respuesta_anulacion_documento(eltipodoc, ElNumeroDoc, laidkey, elusuario, elrutusuario, responselistener);
                RequestQueue queue = Volley.newRequestQueue(anulaciones.this);
                queue.add(anulaciondocumentoRequest);







            }


        });


        //Llama al activity de Menú
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenu = new Intent(anulaciones.this,Menu.class);
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
