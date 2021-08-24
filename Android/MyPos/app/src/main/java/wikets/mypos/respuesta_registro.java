package wikets.mypos;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_registro extends StringRequest {
    private static final String REGISTRO_REQUEST_URL = "http://wikets.cl/MyPos/RegistroUsuario.php";
    private Map<String, String> params;

    public respuesta_registro(String usuario, String nombreusuario, String rutusuario,
                              String contraseñausuario, Response.Listener<String> listener){
        super(Method.POST, REGISTRO_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("usuario", usuario);
        params.put("nombreusuario", nombreusuario);
        params.put("rutusuario", rutusuario);
        params.put("contraseñausuario", contraseñausuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
