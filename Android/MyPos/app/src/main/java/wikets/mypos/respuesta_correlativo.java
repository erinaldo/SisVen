package wikets.mypos;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_correlativo extends StringRequest {
    private static final String CORRELATIVO_REQUEST_URL = "http://wikets.cl/MyPos/RegistroCAF.php";
    private Map<String, String> params;

    public respuesta_correlativo(String local, String rut, String tipodoc, String fecha,
                                 String valorinicial, String valorfinal, String idkey, String usuario,
                                 Response.Listener<String> listener){
        super(Method.POST, CORRELATIVO_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("local", local);
        params.put("rut", rut);
        params.put("tipodoc", tipodoc);
        params.put("fecha", fecha);
        params.put("valorinicial", valorinicial);
        params.put("valorfinal", valorfinal);
        params.put("id_key", idkey);
        params.put("usuario", usuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }

}
