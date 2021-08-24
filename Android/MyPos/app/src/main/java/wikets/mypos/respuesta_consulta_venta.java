package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 **/

public class respuesta_consulta_venta extends StringRequest {
    private static final String CONSULTA_VENTA_REQUEST_URL = "http://wikets.cl/MyPos/onsultaVenta.php";
    private Map<String, String> params;

    public respuesta_consulta_venta(String fechainicio, String fechafinal, String rutcliente,
                                    String tipodoc, String formapago, String numdoc, String mododetalle,
                                    String idkey, String usuario, Response.Listener<String> listener){
        super(Request.Method.POST, CONSULTA_VENTA_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("fecha_inicio", fechainicio);
        params.put("fecha_final", fechafinal);
        params.put("rut_cliente", rutcliente);
        params.put("tipodoc", tipodoc);
        params.put("formapago", formapago);
        params.put("numdoc", numdoc);
        params.put("mododetalle", mododetalle);
        params.put("id_key", idkey);
        params.put("usuario", usuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
