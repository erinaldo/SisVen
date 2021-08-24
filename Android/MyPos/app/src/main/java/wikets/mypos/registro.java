package wikets.mypos;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class registro extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.registro);

        setTitle("Registrarse");

        final EditText EtRut = (EditText) findViewById(R.id.xRut);
        final EditText EtNombre = (EditText) findViewById(R.id.xNombre);
        final EditText EtUsuario = (EditText) findViewById(R.id.xUsuario);
        final EditText EtContraseña = (EditText) findViewById(R.id.xContraseña);
        final Button botonregistrar = (Button) findViewById(R.id.bRegistrar);

        //Llama al activity de Login
        botonregistrar.setOnClickListener(new View.OnClickListener()  {
            @Override
            public void onClick(View view){
                final String Rut = EtRut.getText().toString();
                final String Nombre = EtNombre.getText().toString();
                final String Usuario = EtUsuario.getText().toString();
                final String Contraseña = EtContraseña.getText().toString();

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                Intent abrirlogin = new Intent(registro.this, login.class);
                                registro.this.startActivity(abrirlogin);
                            }else{
                                AlertDialog.Builder builder = new AlertDialog.Builder(registro.this);
                                builder.setMessage("El Registro de Usuario ha Fallado")
                                        .setNegativeButton("Reintentar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }


                    }
                };

                respuesta_registro registroRequest = new respuesta_registro(Usuario, Nombre, Rut, Contraseña, responselistener);
                RequestQueue queue = Volley.newRequestQueue(registro.this);
                queue.add(registroRequest);

            }

        });

    }
}
