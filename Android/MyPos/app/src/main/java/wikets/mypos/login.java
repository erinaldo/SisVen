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

import org.json.JSONException;
import org.json.JSONObject;

import static com.android.volley.toolbox.Volley.*;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class login extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login);
        getSupportActionBar().setTitle("Login");
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setIcon(R.mipmap.ic_launcher);
        final Button bIngreso = (Button) findViewById(R.id.bIngresar);
        Button botonregistrarse = (Button) findViewById(R.id.bRegistrarse);

        final EditText xUsuario = (EditText) findViewById(R.id.xUsuario);
        final EditText xContraseña = (EditText) findViewById(R.id.xContraseña);

        //Verifica Usuario y Llama al activity de Menu
        bIngreso.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {

                if (xUsuario.getText().toString().equals(""))
                {
                    AlertDialog.Builder wMensaje = new AlertDialog.Builder(login.this);
                    wMensaje.setTitle("Error");
                    wMensaje.setMessage("El campo usuario está vacío");
                    wMensaje.setNegativeButton("Aceptar", null);
                    wMensaje.setIcon(R.drawable.error64);
                    wMensaje.create();
                    wMensaje.show();
                    xUsuario.requestFocus();
                    return;
                }
                if (xContraseña.getText().toString().equals(""))
                {
                    AlertDialog.Builder wMensaje = new AlertDialog.Builder(login.this);
                    wMensaje.setTitle("Error");
                    wMensaje.setMessage("El campo contraseña está vacío");
                    wMensaje.setNegativeButton("Aceptar", null);
                    wMensaje.setIcon(R.drawable.error64);
                    wMensaje.create();
                    wMensaje.show();
                    xContraseña.requestFocus();
                    return;
                }
                if (!verificaConexion(login.this)) {
                    AlertDialog.Builder wMensaje = new AlertDialog.Builder(login.this);
                    wMensaje.setTitle("Advertencia");
                    wMensaje.setMessage("No hay conexión a Internet");
                    wMensaje.setNegativeButton("Aceptar", null);
                    wMensaje.setIcon(R.drawable.advertencia64);
                    wMensaje.create();
                    wMensaje.show();
                    return;
                }
                bIngreso.setEnabled(false);
                final String wUsuario = xUsuario.getText().toString();
                final String wContraseña = xContraseña.getText().toString();
                final String wIDKey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                Response.Listener<String> responselistener;
                responselistener = new Response.Listener<String>(){



                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                String wNombreUsuario = jsonResponse.getString("nombreusuario");
                                String wRut = jsonResponse.getString("rutusuario");
                                String wLocal = jsonResponse.getString("localusuario");

                                Intent wActividad = new Intent(login.this, Menu.class);
                                ((variables_gloabales) login.this.getApplication()).setUsuarioActual(wUsuario);
                                ((variables_gloabales) login.this.getApplication()).setNombreUsuarioActual(wNombreUsuario);
                                ((variables_gloabales) login.this.getApplication()).setRutUsuarioActual(wRut);
                                ((variables_gloabales) login.this.getApplication()).setLocalUsuarioActual(wLocal);
                                login.this.startActivity(wActividad);


                            }else
                            {
                                String wMensajeWS=jsonResponse.getString("Mensaje");

                                if (!wMensajeWS.equals(""))
                                {
                                    AlertDialog.Builder wMensaje = new AlertDialog.Builder(login.this);
                                    wMensaje.setTitle("Error");
                                    wMensaje.setMessage(wMensajeWS);
                                    wMensaje.setCancelable(false);
                                    wMensaje.setIcon(R.drawable.error64);
                                    wMensaje.setNegativeButton("Aceptar", null);
                                    wMensaje.create();
                                    wMensaje.show();
                                    bIngreso.setEnabled(true);
                                }
                                else
                                {
                                    AlertDialog.Builder wMensaje = new AlertDialog.Builder(login.this);
                                    wMensaje.setTitle("Error");
                                    wMensaje.setMessage("Los datos ingresados son incorrectos");
                                    wMensaje.setNegativeButton("Aceptar", null);
                                    wMensaje.setIcon(R.drawable.error64);
                                    wMensaje.create();
                                    wMensaje.show();
                                    bIngreso.setEnabled(true);
                                }
                            }

                        } catch (JSONException e) {
                            AlertDialog.Builder wMensaje = new AlertDialog.Builder(login.this);
                            wMensaje.setTitle("Error en procedimiento");
                            wMensaje.setMessage("ha ocurrido un error " + e.toString());
                            wMensaje.setNegativeButton("Aceptar", null);
                            wMensaje.setIcon(R.drawable.error64);
                            wMensaje.create();
                            wMensaje.show();
                            bIngreso.setEnabled(true);
                            //e.printStackTrace();
                        }


                    }
                };

                try
                {
                    WS_Acceso wMetodoWS = new WS_Acceso(wUsuario, wContraseña, wIDKey, responselistener);
                    RequestQueue wRespuestaWS = newRequestQueue(login.this);
                    wRespuestaWS.add(wMetodoWS);
                }
                catch (Exception e)
                {
                    Toast.makeText(login.this,e.toString(),Toast.LENGTH_LONG);
                }


            }
        });


        //Llama al activity de Registro
        botonregistrarse.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                Intent abrirregistro = new Intent(login.this, registro.class);
                startActivity(abrirregistro);
            }


        });

    }

    public static boolean verificaConexion(Context ctx) {
        boolean bConectado = false;
        ConnectivityManager connec = (ConnectivityManager) ctx
                .getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo[] redes = connec.getAllNetworkInfo();
        for (int i = 0; i < 2; i++) {
            if (redes[i].getState() == NetworkInfo.State.CONNECTED) {
                bConectado = true;
            }
        }
        return bConectado;
    }
}
