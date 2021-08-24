package wikets.mypos;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;
import static wikets.mypos.constantes.FIRST_COLUMN;
import static wikets.mypos.constantes.SECOND_COLUMN;
import static wikets.mypos.constantes.THIRD_COLUMN;
import static wikets.mypos.constantes.FOURTH_COLUMN;

import static wikets.mypos.constantes.FIVE_COLUMN;
import static wikets.mypos.constantes.SIX_COLUMN;
import static wikets.mypos.constantes.SEVEN_COLUMN;
import static wikets.mypos.constantes.EIGHT_COLUMN;
import static wikets.mypos.constantes.NINE_COLUMN;
/**
 * Created by Miguel on 04-05-2018.
 */

public class listado_ventas_adapter extends BaseAdapter {
    public ArrayList<HashMap<String, String>> list;
    Activity activity;
    TextView txtFirst;
    TextView txtSecond;
    TextView txtThird;
    TextView txtFourth;
    TextView txtFive;
    TextView txtSix;
    TextView txtSeven;
    TextView txtEight;
    TextView txtNine;


    public listado_ventas_adapter(Activity activity,ArrayList<HashMap<String, String>> list){
        super();
        this.activity=activity;
        this.list=list;
    }

    @Override
    public int getCount() {
        // TODO Auto-generated method stub
        return list.size();
    }

    @Override
    public Object getItem(int position) {
        // TODO Auto-generated method stub
        return list.get(position);
    }

    @Override
    public long getItemId(int position) {
        // TODO Auto-generated method stub
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // TODO Auto-generated method stub

        LayoutInflater inflater=activity.getLayoutInflater();

        if(convertView == null){

            convertView=inflater.inflate(R.layout.listado_ventas, null);

            txtFirst=(TextView) convertView.findViewById(R.id.fecha);
            txtSecond=(TextView) convertView.findViewById(R.id.cliente);
            txtThird=(TextView) convertView.findViewById(R.id.numdoc);
            txtFourth=(TextView) convertView.findViewById(R.id.monto);

        }

        HashMap<String, String> map=list.get(position);
        txtFirst.setText(map.get(FIRST_COLUMN));
        txtSecond.setText(map.get(SECOND_COLUMN));
        txtThird.setText(map.get(THIRD_COLUMN));
        txtFourth.setText(map.get(FOURTH_COLUMN));

        return convertView;
    }

}
