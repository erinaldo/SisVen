package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;

/**
 * Created by Miguel on 03-05-2018.
 */

public class venta_vuelto extends AppCompatActivity {

    ///// Declaracion de variables
    private EditText xmontodelaboleta;
    private int boletanum;
    private int efectivonum;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.venta_vuelto);

        setTitle("Boleta Simple");

        final EditText EtMonto = (EditText) findViewById(R.id.xMonto);
        final EditText EtEfectivo = (EditText) findViewById(R.id.xEfectivo);
        final EditText EtVuelto = (EditText) findViewById(R.id.xVuelto);
        //final EditText EtFocus = (EditText) findViewById(R.id.pruebax);

        //// Da Formato a los campos Numericos
        EtMonto.addTextChangedListener(new NumberTextWatcher(EtMonto));
        EtEfectivo.addTextChangedListener(new NumberTextWatcher(EtEfectivo));
        EtVuelto.addTextChangedListener(new NumberTextWatcher(EtVuelto));
        EtMonto.setText("");
        xmontodelaboleta = (EditText) findViewById(R.id.xMonto);

        EtMonto.requestFocus();
        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);

        //// Precarga el monto de la boleta y asigna foco
        Intent obtenerextra = getIntent();
        Bundle extras = obtenerextra.getExtras();

        if (extras != null) {
            String datomontoboleta=(String)extras.get("monto_boleta");

            if ( (datomontoboleta == null) || (datomontoboleta.isEmpty()) ) {
                EtMonto.requestFocus();
            }
            else{
                EtMonto.setText(datomontoboleta);
                EtEfectivo.requestFocus();
            }


        }

        //// Calcula el Vuelto
        EtVuelto.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            public void onFocusChange(View v, boolean hasFocus) {
                final String montodelaboleta = EtMonto.getText().toString().replace(".", "");
                final String montodelefectivo = EtEfectivo.getText().toString().replace(".", "");
                boletanum = Integer.parseInt(montodelaboleta);
                efectivonum = Integer.parseInt(montodelefectivo);

                final Integer diferencia = (efectivonum - boletanum);

                final String elvuelto = Integer.toString(diferencia);

                EtVuelto.setText(elvuelto);

                InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(EtVuelto.getWindowToken(), 0);
                findViewById(R.id.bEmitir).requestFocus();
            }
        });


        ////////// Define botones de accion
        Button botonvolver = (Button) findViewById(R.id.bVolver);
        Button botonemitirboleta = (Button) findViewById(R.id.bEmitir);
        Button botonquitar = (Button) findViewById(R.id.bQuitar);

        //Llama al activity de Menu Ventas
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenuventas = new Intent(venta_vuelto.this,menu_ventas.class);
                startActivity(abrirmenuventas);
            }


        });

        //Llama al activity de Preview
        botonemitirboleta.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirpreview = new Intent(venta_vuelto.this,venta_sin_detalle_preview.class);
                String xMonto_Boleta = xmontodelaboleta.getText().toString();
                String elmodo = "con";
                abrirpreview.putExtra("monto_boleta",xMonto_Boleta);
                abrirpreview.putExtra("modo",elmodo);
                startActivity(abrirpreview);
            }


        });

        //Llama al activity de Boleta Simple
        botonquitar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirboletasimple = new Intent(venta_vuelto.this,venta_sin_detalle.class);
                startActivity(abrirboletasimple);
            }


        });

    }
}
