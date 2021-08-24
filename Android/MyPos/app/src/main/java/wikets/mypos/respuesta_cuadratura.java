package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_cuadratura extends StringRequest {
    private static final String CUADRATURA_REQUEST_URL = "http://wikets.cl/MyPos/Cuadratura.php";
    private Map<String, String> params;

    public respuesta_cuadratura(String idkey, String usuario, Response.Listener<String> listener){
        super(Request.Method.POST, CUADRATURA_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("id_key", idkey);
        params.put("usuario", usuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
