//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//namespace AdsUtils {
//    public static class Extentions {
//        public enum Axis {
//            X,
//            Y,
//            Z
//        }

//        public static void SetAlpha(this Graphic graphic, float alpha) {
//            var color = graphic.color;
//            color.a = alpha;
//            graphic.color = color;
//        }

//        public static void SetAxisValue(this Transform transform, Axis axis, float value, bool local = false) {
//            var pos = local ? transform.localPosition : transform.position;
//            switch (axis) {
//                case Axis.X:
//                    pos.x = value;
//                    break;
//                case Axis.Y:
//                    pos.y = value;
//                    break;
//                case Axis.Z:
//                    pos.z = value;
//                    break;
//            }
//            if (local) transform.localPosition = pos;
//            else transform.position = pos;
//        }

//        public static bool IsEmptyOrNull(this string text) {
//            if (text == null) return true;
//            return text.Length == 0;
//        }

//        public static void RunDelay(this MonoBehaviour mono, Action action, float delay = -1) {
//            mono.StartCoroutine(Task(action, delay));
//        }

//        private static IEnumerator Task(Action action, float delay) {
//            if (delay < 0)
//                yield return WAIT_FOR_END_OF_FRAME;
//            else yield return new WaitForSeconds(delay);
//            action();
//        }

//        private static readonly WaitForEndOfFrame WAIT_FOR_END_OF_FRAME = new WaitForEndOfFrame();

//        public static WaitForEndOfFrame WaitForEndOfFrame(this MonoBehaviour mono) {
//            return WAIT_FOR_END_OF_FRAME;
//        }
//    }
//}