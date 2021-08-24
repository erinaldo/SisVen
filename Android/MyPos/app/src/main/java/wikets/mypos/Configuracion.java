package wikets.mypos;

import android.content.Context;
import android.content.SharedPreferences;

/**
 * Created by Miguel on 10-11-2017.
 */

public class Configuracion {

    private final String SHARED_PREFS_FILE = "HMPrefs";
    private final String KEY_WS = "IP";

    private Context mContext;
    public Configuracion(Context context){
        mContext = context;
    }

    private SharedPreferences getSettings(){
        return mContext.getSharedPreferences(SHARED_PREFS_FILE, 0);
    }

    public String getIPServidor(){
        return getSettings().getString(KEY_WS, null);
    }

    public void setIPServidor(String WS){
        SharedPreferences.Editor editor = getSettings().edit();
        editor.putString(KEY_WS, WS );
        editor.commit();
    }


}