package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_lista_precio extends StringRequest {
    private static final String LISTADO_PRECIOS_REQUEST_URL = "http://wikets.cl/MyPos/ListadoPrecios.php";
    private Map<String, String> params;

    public respuesta_lista_precio(String tipomodo, String idkey, String rutcliente, Response.Listener<String> listener){
        super(Request.Method.POST, LISTADO_PRECIOS_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("tipomodo", tipomodo);
        params.put("id_key", idkey);
        params.put("rut", rutcliente);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
