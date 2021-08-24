package wikets.mypos;

import android.support.v7.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.github.pinball83.maskededittext.MaskedEditText;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Miguel on 03-05-2018.
 * */

public class clientes extends AppCompatActivity {
    private int elpreciodelarticulo;
    private int labarra1;
    private int labarra2;
    private int labarra3;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.clientes);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Clientes");
        actionbar.setSubtitle("M-05");

        //  final EditText EtxRutCliente = (EditText) findViewById(R.id.xRutCliente);
        final MaskedEditText maskedEditText = (MaskedEditText) this.findViewById(R.id.masked_edit_text);
        final EditText EtxNombreCliente = (EditText) findViewById(R.id.xNombreCliente);
        final EditText EtxxGiroCliente = (EditText) findViewById(R.id.xGiroCliente);
        final EditText EtxDireccionCliente = (EditText) findViewById(R.id.xDireccionCliente);
        final EditText EtxCiudadCliente = (EditText) findViewById(R.id.xCiudadCliente);
        final EditText EtxComunaCliente = (EditText) findViewById(R.id.xComunaCliente);
        final EditText EtxEmailCliente = (EditText) findViewById(R.id.xEmailCliente);

        Button botonvolver = (Button) findViewById(R.id.bVolver);
        Button botonguardar = (Button) findViewById(R.id.bGuardar);

        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
        imm.hideSoftInputFromWindow(maskedEditText.getWindowToken(), 0);

        //Llama al activity de Menú
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenu = new Intent(clientes.this,Menu.class);
                startActivity(abrirmenu);
            }


        });

        final String rutdelusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();
        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();

        //  Registra Precios
        botonguardar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                if (!verificaConexion(clientes.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(clientes.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                final String elrutdelcliente = maskedEditText.getUnmaskedText();

                final String elnombredelcliente = EtxNombreCliente.getText().toString();
                final String elgirodelcliente = EtxxGiroCliente.getText().toString();
                final String ladirecciondelcliente = EtxDireccionCliente.getText().toString();
                final String laciudaddelcliente = EtxCiudadCliente.getText().toString();
                final String lacomunadelcliente = EtxComunaCliente.getText().toString();
                final String elemaildedelcliente = EtxEmailCliente.getText().toString();

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Cliente Registrado Correctamente", Toast.LENGTH_SHORT);
                                mensajeconfirmacion.show();
                                Intent abrirprecios = new Intent(clientes.this, clientes.class);
                                clientes.this.startActivity(abrirprecios);
                            }else{
                                AlertDialog.Builder builder = new AlertDialog.Builder(clientes.this);
                                builder.setMessage("Cliente ya se encuentra Registrado")
                                        .setNegativeButton("Aceptar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }


                    }
                };

                respuesta_clientes clientesRequest = new respuesta_clientes(elrutdelcliente, elnombredelcliente, elgirodelcliente, ladirecciondelcliente, laciudaddelcliente, lacomunadelcliente, elemaildedelcliente, laidkey, rutdelusuario, elusuario, responselistener);
                RequestQueue queue = Volley.newRequestQueue(clientes.this);
                queue.add(clientesRequest);



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
