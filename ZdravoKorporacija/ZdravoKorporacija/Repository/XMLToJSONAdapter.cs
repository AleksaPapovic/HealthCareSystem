using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository
{
    class XMLToJSONAdapter : IConverterXMLToJSON
	{
		private readonly XMLAPI _xmlConverter;

		public XMLToJSONAdapter(XMLAPI xmlConverter)
		{
			_xmlConverter = xmlConverter;
		}

		public string ConvertXmlToJson()
		{

			string jsonText = JsonConvert.SerializeXNode(_xmlConverter.GetXML());
			return jsonText;
		}
	}
}
