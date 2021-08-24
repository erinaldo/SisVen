package wikets.mypos;

import android.content.Intent;
import android.graphics.Typeface;
import android.net.ParseException;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;

/**
 * Created by Miguel on 03-05-2018.
 */

public class venta_diaria extends AppCompatActivity {
    int sumatotal_ventadiaria;
    int lasfacturas_;
    int lasboletas_;
    int lasntd_;
    int lasndd_;
    int lasfactturasexentas_;
    int lasguias_;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.venta_diaria);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Venta Diaria");
        actionbar.setSubtitle("MC-01");

        final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();

        final TextView lafechactual = (TextView) findViewById(R.id.xFecha);
        final TextView facturas = (TextView) findViewById(R.id.xFacturas);
        final TextView boletas = (TextView) findViewById(R.id.xBoletas);
        final TextView ndc = (TextView) findViewById(R.id.xNDC);
        final TextView ndd = (TextView) findViewById(R.id.xNDD);
        final TextView facturas_exentas = (TextView) findViewById(R.id.xFacturasExentas);
        final TextView guias = (TextView) findViewById(R.id.xGuias);
        final TextView eltotal = (TextView) findViewById(R.id.xTotal);

        final Button botonvolver = (Button) findViewById(R.id.bVolver);

        eltotal.setTypeface(null, Typeface.BOLD);


        Response.Listener<String> responselistener = new Response.Listener<String>(){

            @Override
            public void onResponse(String response) {
                try {
                    JSONObject jsonResponse = new JSONObject(response);
                    boolean success = jsonResponse.getBoolean("success");

                    if(success){
                        String lasfacturas = jsonResponse.getString("F");
                        String lasboletas = jsonResponse.getString("B");
                        String lasnotasdecredito = jsonResponse.getString("N");
                        String lasnotasdedebito = jsonResponse.getString("D");
                        String lasfacturasexentas = jsonResponse.getString("E");
                        String lasguias = jsonResponse.getString("G");
                        String lafechaactual = jsonResponse.getString("fecha_actual");


                        if (lasfacturas.equals("null")){
                            facturas.setText("$ 0");
                            lasfacturas_ = 0;
                        }else{
                            lasfacturas_ = jsonResponse.getInt("F");
                            final String montofacturas = formatodenumero(lasfacturas);
                            facturas.setText("$" + montofacturas);
                        }

                        if (lasboletas.equals("null")){
                            boletas.setText("$ 0");
                            lasboletas_ = 0;
                        }else{
                            final String montoboletas = formatodenumero(lasboletas);
                            lasboletas_ = jsonResponse.getInt("B");
                            boletas.setText("$" + montoboletas);
                        }

                        if (lasnotasdecredito.equals("null")){
                            ndc.setText("$ 0");
                            lasntd_ = 0;
                        }else{
                            final String montonotasdecredito = formatodenumero(lasnotasdecredito);
                            lasntd_ = jsonResponse.getInt("N");
                            ndc.setText("$" + montonotasdecredito);
                        }

                        if (lasnotasdedebito.equals("null")){
                            ndd.setText("$ 0");
                            lasndd_ = 0;
                        }else{
                            lasndd_ = jsonResponse.getInt("D");
                            final String montonotasdedebito = formatodenumero(lasnotasdedebito);
                            ndd.setText("$" + montonotasdedebito);
                        }

                        if (lasfacturasexentas.equals("null")){
                            facturas_exentas.setText("$ 0");
                            lasfactturasexentas_ = 0;
                        }else{
                            final String montolasfacturase = formatodenumero(lasfacturasexentas);
                            lasfactturasexentas_ = jsonResponse.getInt("E");
                            facturas_exentas.setText("$" + montolasfacturase);
                        }

                        if (lasguias.equals("null")){
                            guias.setText("$ 0");
                            lasguias_ = 0;
                        }else{
                            final String montolasguias = formatodenumero(lasguias);
                            lasguias_ = jsonResponse.getInt("G");
                            guias.setText("$" + montolasguias);
                        }

                        sumatotal_ventadiaria = lasfacturas_ + lasboletas_ + lasntd_ + lasndd_ + lasfactturasexentas_ + lasguias_;

                        final String totalventadiaria = formatodenumero(sumatotal_ventadiaria+"");

                        eltotal.setText("$ " + totalventadiaria);
                        lafechactual.setText(lafechaactual);


                    }else{
                        AlertDialog.Builder builder = new AlertDialog.Builder(venta_diaria.this);
                        builder.setMessage("La Consulta Venta Diaria ha Fallado")
                                .setNegativeButton("Aceptar", null)
                                .create()
                                .show();
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }


            }
        };

        respuesta_venta_diaria ventadiariaRequest = new respuesta_venta_diaria(laidkey, elusuario, responselistener);
        RequestQueue queue = Volley.newRequestQueue(venta_diaria.this);
        queue.add(ventadiariaRequest);



        //Llama al activity de Menu de Consultas
        botonvolver.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                Intent abrirregistro = new Intent(venta_diaria.this, consultas.class);
                startActivity(abrirregistro);
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
        } catch (java.text.ParseException e) {
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
