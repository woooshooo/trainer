﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace SharpUpdate
{
    public class SharpUpdateXml
    {
        private Version version;
        private Uri uri;
        private string fileName;
        private string md5;
        private string description;
        private string launchArgs;

        internal Version Version { get { return this.version; } }
        internal Uri Uri { get { return this.uri; } }
        internal string FileName { get { return this.fileName; } }
        internal string MD5 { get { return this.md5; } }
        internal string Description { get { return this.description; } }
        internal string LaunchArgs { get { return this.launchArgs; } }

        internal SharpUpdateXml(Version version, Uri uri, string fileName, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.fileName = fileName;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        internal bool IsNewerThan(Version v) {
            return this.version > v;
        }

        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
                resp.Close();

                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static SharpUpdateXml Parse(Uri location, string appID) {

            Version version = null;
            string url = "" , fileName = "" , md5 = "" , description = "" , launchArgs = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                XmlNode node = doc.DocumentElement.SelectSingleNode("//update[@appId='" + appID + "']");

                if (node == null)
                {
                    return null;
                }

                version = Version.Parse(node["version"].InnerText);
                url = node["url"].InnerText;
                fileName = node["fileName"].InnerText;
                md5 = node["md5"].InnerText;
                description = node["description"].InnerText;            
                launchArgs = node["launchArgs"].InnerText;

                return new SharpUpdateXml(version, new Uri(url), fileName, md5, description, launchArgs);
            }
            catch (Exception)
            {

                return null;
            }
        
        }
    }
}
