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

/**
 * Created by Miguel on 03-05-2018.
 */

public class consultas extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.consultas);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Consultas");
        actionbar.setSubtitle("MC-00");

        Button botonventadiaria = (Button) findViewById(R.id.bVentaDiaria);
        Button botonconsultaventa = (Button) findViewById(R.id.bConsultaVenta);
        Button botoncuadratura = (Button) findViewById(R.id.bCuadratura);
        Button botonlistaprecios = (Button) findViewById(R.id.bListaPrecios);
        Button botonvolver = (Button) findViewById(R.id.bVolver);

        //Llama al activity de Venta Diaria
        botonventadiaria.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                if (!verificaConexion(consultas.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(consultas.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }
                Intent abrirventadiaria = new Intent(consultas.this, venta_diaria.class);
                startActivity(abrirventadiaria);
            }


        });

        //Llama al activity de Consulta Venta
        botonconsultaventa.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                if (!verificaConexion(consultas.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(consultas.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }
                Intent abrirconsultaventa = new Intent(consultas.this, consultas.class);
                startActivity(abrirconsultaventa);
            }


        });

        //Llama al activity de Cuadratura
        botoncuadratura.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                if (!verificaConexion(consultas.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(consultas.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }
                Intent abrircuadratura = new Intent(consultas.this, cuadratura.class);
                startActivity(abrircuadratura);
            }


        });

        //Llama al activity de Lista de Precios
        botonlistaprecios.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                if (!verificaConexion(consultas.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(consultas.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }
                Intent abrirlistaprecios = new Intent(consultas.this, lista_precio.class);
                startActivity(abrirlistaprecios);
            }


        });

        //Llama al activity de Menu (Volver)
        botonvolver.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                Intent abrirmenu = new Intent(consultas.this, Menu.class);
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
