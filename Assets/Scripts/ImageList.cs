using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;

namespace UI
{
    public class ImageList : MonoBehaviour
    {

        public Transform content;
        private List<DAO.Image> m_Images;

        private void Start()
        {
            m_Images = new List<DAO.Image>();

            m_Images.Add(new DAO.Image("https://picsum.photos/200/300", "랜덤 이미지"));
            m_Images.Add(new DAO.Image("https://picsum.photos/200/300", "랜덤 이미지"));
            m_Images.Add(new DAO.Image("https://picsum.photos/200/300", "랜덤 이미지"));
            m_Images.Add(new DAO.Image("https://picsum.photos/200/300", "랜덤 이미지"));
            m_Images.Add(new DAO.Image("https://picsum.photos/200/300", "랜덤 이미지"));

            LoadImage();
        }

        private void LoadImage()
        {
            foreach (var item in m_Images)
            {
                HTTPRequest request = new HTTPRequest(new Uri(item.url), ImageDownloaded);

                GameObject frame = new GameObject();
                RawImage image = frame.AddComponent<RawImage>();

                frame.transform.SetParent(content);
                item.image = image;
                item.sampleImage = frame.AddComponent<SampleImage>();
                request.Tag = item;

                request.Send();
            }
        }

        private void ImageDownloaded(HTTPRequest req, HTTPResponse res)
        {
            switch (req.State)
            {
                case HTTPRequestStates.Finished:
                    if (res.IsSuccess)
                    {
                        try
                        {
                            DAO.Image image = req.Tag as DAO.Image;
                            image.image.texture = res.DataAsTexture2D;
                            image.image.SetNativeSize();
                            image.sampleImage.texture = image.image.texture;
                        }
                        catch (Exception e)
                        {
                            Debug.LogFormat("이미지를 로드하던 중 에러 발생 {}", e);
                        }
                        Debug.Log("이미지 로드 완료");
                    }
                    else
                    {
                        Debug.LogErrorFormat("서버 에러 발생 code: {}, msg: {}", res.StatusCode, res.Message);
                    }
                    break;
                default:
                    Debug.LogError(req.State.ToString());
                    break;
            }
        }
    }
}