using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebBrowser
{
    public class RssReader
    {
        //url vericim
        //Web client indiricem
        //xmlDocument
        //Haber Listesi
        //rss readerı kullanmak için url vermem lazım dedim.
        //o yüzden constructor ıma parametre olarak url verdim.
        public RssReader(string _url)
        {//Site url i denilen nesneyi kullanıcının gireceği parametreden çekmelisin dedim.
            this.siteUrl = _url;
            xDoc = new XmlDocument();
        }
        private string siteUrl;
        private XmlDocument xDoc;
        //Rss Bilgilerini bunun içerisinden çekicem
        private void GetRssNews()
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string xmlData = wc.DownloadString(siteUrl);
            xDoc.LoadXml(xmlData);
        }
        //Geriye haber döndürmek için bir liste
        public List<Haber> GetNews()
        {
            //boş liste oluşturdum.
            List<Haber> haberlistesi = new List<Haber>();
            //içini yukarda haberleri getirdiğim metot da dolduruyorum.
            GetRssNews();
            XmlNodeList nodlar = xDoc.GetElementsByTagName("item");
            foreach (XmlNode nod in nodlar)
            {
                try
                {
                    Haber h = new Haber();
                    h.Haberbasligi = nod.SelectSingleNode("title").InnerText;
                    h.Link = nod.SelectSingleNode("link").InnerText;
                    haberlistesi.Add(h);
                }
                //Boş geldiğinde devam etsin hata vermesin
                catch
                {

                    continue;
                }
            }
            return haberlistesi;
        }
    }
}
