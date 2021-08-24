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
 **/

public class menu_ventas extends AppCompatActivity{

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menu_ventas);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Ventas");
        actionbar.setSubtitle("MV-00");

        //Botones del Menu Ventas
        Button botonventasimple = (Button) findViewById(R.id.bVentaSimple);
        Button botonventadoc = (Button) findViewById(R.id.bVentaDoc);
        Button botonmenu = (Button) findViewById(R.id.bVolver);

        //Llama al activity de Boleta Simple
        botonventasimple.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                if (!verificaConexion(menu_ventas.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(menu_ventas.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }
                Intent abrirventasimple = new Intent(menu_ventas.this,venta_sin_detalle.class);
                startActivity(abrirventasimple);
            }


        });

        //Llama al activity de Documento Electronico
        botonventadoc.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                if (!verificaConexion(menu_ventas.this)) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(menu_ventas.this);
                    builder.setMessage("SIN INTERNET ... ")
                            .setNegativeButton("Aceptar", null)
                            .create()
                            .show();
                    return;
                }
                Intent abrirventadoc = new Intent(menu_ventas.this,venta_detallada.class);
                startActivity(abrirventadoc);
            }


        });

        //Llama al activity de Menu Ventas (VOLVER)
        botonmenu.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenu = new Intent(menu_ventas.this,Menu.class);
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
