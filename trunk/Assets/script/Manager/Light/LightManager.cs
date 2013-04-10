using UnityEngine;
using System.Collections;

namespace Loop {

    public static class LightManager {

        private static GameObject _playerLight;

        public static IEnumerator PlayerLightUp() {

            _playerLight = GameObject.Find("PlayerLight");
            Light lt = _playerLight.light;
            lt.intensity = Mathf.Lerp(lt.intensity, LightConstants.PLAYER_LIGHT_INTENSITY,
                Time.deltaTime * LightConstants.PLAYER_LIGHT_UP_DAMP);
            Debug.Log(lt.intensity);
            yield return null;

        }
    }
}