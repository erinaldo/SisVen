package wikets.mypos;

import android.content.Intent;
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
 **/

public class cuadratura extends AppCompatActivity {
    int sumatotal_ventadiaria;
    int lasfacturas_;
    int lasboletas_;
    int lasntd_;
    int lasndd_;
    int lasfactturasexentas_;
    int lasguias_;
    int losefectivos_;
    int lasredcompra_;
    int lastarjetas_;
    int loscheques_;
    int losvales_;
    int lasnotas_;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cuadratura);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Cuadratura");
        actionbar.setSubtitle("MC-03");

        final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
        final String elusuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();

        final TextView lafechactual = (TextView) findViewById(R.id.xFecha);
        final TextView eltotal = (TextView) findViewById(R.id.xTotal);
        final TextView facturas = (TextView) findViewById(R.id.xFacturas);
        final TextView boletas = (TextView) findViewById(R.id.xBoletas);
        final TextView ndc = (TextView) findViewById(R.id.xNDC);
        final TextView ndd = (TextView) findViewById(R.id.xNDD);
        final TextView facturas_exentas = (TextView) findViewById(R.id.xFacturasExentas);
        final TextView guias = (TextView) findViewById(R.id.xGuias);
        final TextView efectivo = (TextView) findViewById(R.id.xEfectivo);
        final TextView redcompra = (TextView) findViewById(R.id.xRedCompra);
        final TextView tarjeta = (TextView) findViewById(R.id.xTarjeta);
        final TextView cheque = (TextView) findViewById(R.id.xCheque);
        final TextView vale = (TextView) findViewById(R.id.xVale);
        final TextView notas = (TextView) findViewById(R.id.xNotas);

        final Button botonvolver = (Button) findViewById(R.id.bVolver);

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


                        String losefectivos = jsonResponse.getString("FPE");
                        String lasredcompra = jsonResponse.getString("FPR");
                        String lastarjetas = jsonResponse.getString("FPT");
                        String loscheques = jsonResponse.getString("FPC");
                        String losvales = jsonResponse.getString("FPV");
                        String lasnotas = jsonResponse.getString("FPN");

                        if (losefectivos.equals("null")){
                            efectivo.setText("$ 0");
                            losefectivos_ = 0;
                        }else{
                            losefectivos_ = jsonResponse.getInt("FPE");
                            final String montoefectivo = formatodenumero(losefectivos_+"");
                            efectivo.setText("$" + montoefectivo);
                        }

                        if (lasredcompra.equals("null")){
                            redcompra.setText("$ 0");
                            lasredcompra_ = 0;
                        }else{
                            lasredcompra_ = jsonResponse.getInt("FPR");
                            final String montored = formatodenumero(lasredcompra_+"");
                            redcompra.setText("$" + montored);
                        }

                        if (lastarjetas.equals("null")){
                            tarjeta.setText("$ 0");
                            lastarjetas_ = 0;
                        }else{
                            lastarjetas_ = jsonResponse.getInt("FPT");
                            final String montotarjetas = formatodenumero(lastarjetas_+"");
                            tarjeta.setText("$" + montotarjetas);
                        }

                        if (loscheques.equals("null")){
                            cheque.setText("$ 0");
                            loscheques_ = 0;
                        }else{
                            loscheques_ = jsonResponse.getInt("FPC");
                            final String montocheques = formatodenumero(loscheques_+"");
                            cheque.setText("$" + montocheques);
                        }

                        if (losvales.equals("null")){
                            vale.setText("$ 0");
                            losvales_ = 0;
                        }else{
                            losvales_ = jsonResponse.getInt("FPV");
                            final String montovales = formatodenumero(losvales_+"");
                            vale.setText("$" + montovales);
                        }

                        if (lasnotas.equals("null")){
                            notas.setText("$ 0");
                            lasnotas_ = 0;
                        }else{
                            lasnotas_ = jsonResponse.getInt("FPN");
                            final String montolasnotas = formatodenumero(lasnotas_+"");
                            notas.setText("$" + montolasnotas);
                        }


                    }else{
                        AlertDialog.Builder builder = new AlertDialog.Builder(cuadratura.this);
                        builder.setMessage("La Consulta Cuadratura ha Fallado")
                                .setNegativeButton("Aceptar", null)
                                .create()
                                .show();
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }


            }
        };

        respuesta_cuadratura cuadraturaRequest = new respuesta_cuadratura(laidkey, elusuario, responselistener);
        RequestQueue queue = Volley.newRequestQueue(cuadratura.this);
        queue.add(cuadraturaRequest);



        //Llama al activity de Menu de Consultas
        botonvolver.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                Intent abrirregistro = new Intent(cuadratura.this, consultas.class);
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
