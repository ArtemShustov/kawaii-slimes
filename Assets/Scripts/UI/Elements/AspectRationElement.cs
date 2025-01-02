using UnityEngine;
using UnityEngine.UIElements;

namespace Game.UI.Elements {
    // Custom element that lays out its contents following a specific aspect ratio.
    [UxmlElement]
    public partial class AspectRatioElement: VisualElement {
        [UxmlAttribute("ratio")]
        public float Ratio {
            get => _ratio;
            set {
                _ratio = value;
                UpdateAspect();
            }
        }
        private float _ratio = 1;

        public AspectRatioElement() {
            RegisterCallback<GeometryChangedEvent>(UpdateAspectAfterEvent);
            RegisterCallback<AttachToPanelEvent>(UpdateAspectAfterEvent);
        }


        private void UpdateAspect() {
            style.height = resolvedStyle.width * _ratio;
        }

        private static void UpdateAspectAfterEvent(EventBase evt) {
            var element = evt.target as AspectRatioElement;
            element?.UpdateAspect();
        }
    }
}