package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.ParseException;

/**
 * Created by Miguel on 03-05-2018.
 */

public class venta_sin_detalle extends AppCompatActivity {

    ///// Declaracion de variables
    private EditText xmontodelaboleta;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.venta_sin_detalle);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Boleta Simple");
        actionbar.setSubtitle("MV-01");

        /// Da Formato al monto de la boleta
        EditText Et = (EditText) findViewById(R.id.xMontoBoleta);
        Et.addTextChangedListener(new NumberTextWatcher(Et));
        Et.setText("");
        ////// Posiciona el focus en el monto y despliega automaticamente el teclado
        Et.requestFocus();
        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);

        /////// Define botones de accion
        Button botonvolver = (Button) findViewById(R.id.bVolver);
        Button botonemitirboleta = (Button) findViewById(R.id.bEmitirBoleta);
        Button botonvuelto = (Button) findViewById(R.id.bVuelto);

        xmontodelaboleta = (EditText) findViewById(R.id.xMontoBoleta);




        //Llama al activity de Preview
        botonemitirboleta.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirpreview = new Intent(venta_sin_detalle.this,venta_sin_detalle.class);
                String xMonto_Boleta = xmontodelaboleta.getText().toString();
                String elmodo = "sin";
                abrirpreview.putExtra("monto_boleta",xMonto_Boleta);
                abrirpreview.putExtra("modo",elmodo);
                startActivity(abrirpreview);
            }


        });

        //Llama al activity de Vuelto
        botonvuelto.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirvuelto = new Intent(venta_sin_detalle.this,venta_vuelto.class);
                String xMonto_Boleta = xmontodelaboleta.getText().toString();
                abrirvuelto.putExtra("monto_boleta",xMonto_Boleta);
                startActivity(abrirvuelto);
            }


        });

        //Llama al activity de Menu Ventas (VOLVER)
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenuventas = new Intent(venta_sin_detalle.this,menu_ventas.class);
                startActivity(abrirmenuventas);
            }


        });

    }
}



class NumberTextWatcher implements TextWatcher {

    private DecimalFormat df;
    private DecimalFormat dfnd;
    private boolean hasFractionalPart;

    private EditText et;
    private String Str;


    public NumberTextWatcher(EditText et)
    {

        DecimalFormatSymbols simbolos = new DecimalFormatSymbols();
        simbolos.setDecimalSeparator(',');
        simbolos.setGroupingSeparator('.');

        df = new DecimalFormat("#,###.##", simbolos);
        // df.setDecimalSeparatorAlwaysShown(true);
        dfnd = new DecimalFormat("#,###", simbolos);
        this.et = et;
        hasFractionalPart = false;


    }

    @SuppressWarnings("unused")
    private static final String TAG = "NumberTextWatcher";

    @Override
    public void afterTextChanged(Editable s)
    {
        et.removeTextChangedListener(this);

        try {
            int inilen, endlen;
            inilen = et.getText().length();

            String v = s.toString().replace(String.valueOf(df.getDecimalFormatSymbols().getGroupingSeparator()), "");
            Number n = df.parse(v);
            int cp = et.getSelectionStart();
            if (hasFractionalPart) {
                /// setea valor
                et.setText(df.format(n));
            } else {
                /// setea valor
                et.setText(dfnd.format(n));
            }
            endlen = et.getText().length();
            int sel = (cp + (endlen - inilen));
            if (sel > 0 && sel <= et.getText().length()) {
                et.setSelection(sel);
            } else {
                // place cursor at the end?
                et.setSelection(et.getText().length() - 1);
            }
        } catch (NumberFormatException nfe) {
            // do nothing?
        } catch (ParseException e) {
            // do nothing?
        }

        et.addTextChangedListener(this);
    }

    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after)
    {
    }

    @Override
    public void onTextChanged(CharSequence s, int start, int before, int count)
    {
        if (s.toString().contains(String.valueOf(df.getDecimalFormatSymbols().getDecimalSeparator())))
        {
            hasFractionalPart = true;
        } else {
            hasFractionalPart = false;
        }
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
