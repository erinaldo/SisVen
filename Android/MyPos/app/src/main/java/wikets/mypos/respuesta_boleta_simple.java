package wikets.mypos;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_boleta_simple extends StringRequest {
    private static final String REGISTROBOLETASIMPLE_REQUEST_URL = "http://wikets.cl/MyPos/RegistroBoletaSimple.php";
    private Map<String, String> params;

    public respuesta_boleta_simple(Integer montoboleta, String idkey, String usuario, String rutusuario, Response.Listener<String> listener){
        super(Method.POST, REGISTROBOLETASIMPLE_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("montoboleta", montoboleta + "");
        params.put("id_key", idkey);
        params.put("usuario", usuario);
        params.put("rutusuario", rutusuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
