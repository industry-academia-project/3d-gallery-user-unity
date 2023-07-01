using UnityEngine.UI;

namespace DAO
{
    public class Image
    {
        public string url;
        public string desc;

        public RawImage image;

        public SampleImage sampleImage;

        public Image(string url, string desc)
        {
            this.url = url;
            this.desc = desc;
        }

        public Image()
            : this("", "")
        {

        }
    }
}