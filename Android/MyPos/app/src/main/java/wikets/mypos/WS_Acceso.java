package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class WS_Acceso extends StringRequest
{
    private static final String LOGEO_REQUEST_URL ="http://wikets.cl/MyPos/LoginUsuario.php";
    private Map<String, String> params;

    public WS_Acceso(String usuario, String contraseñausuario, String idkey, Response.Listener<String> listener){
        super(Request.Method.POST, LOGEO_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("usuario", usuario);
        params.put("password", contraseñausuario);
        params.put("id_key", idkey);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }

}
