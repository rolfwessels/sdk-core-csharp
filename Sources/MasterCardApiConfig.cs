using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Mastercard.SDK
{
	class  MasterCardApiConfig
	{
		private static String CLIENT_ID;
		public static Boolean SANDBOX = true;
		public static Boolean DEBUG = false;
		private static AsymmetricAlgorithm PRIVATE_KEY;

		public static void setP12(String filePath, String password){
			X509Certificate2 cert = new X509Certificate2(filePath, password);
			MasterCardApiConfig.PRIVATE_KEY = cert.PrivateKey;
		}

		public static String getClientId() {
			return MasterCardApiConfig.CLIENT_ID;
		}

		public static AsymmetricAlgorithm getPrivateKey() {
			return PRIVATE_KEY;
		}

		public static void setClientId(String clientId) {
			MasterCardApiConfig.CLIENT_ID = clientId;
		}

		public static void setDebug(Boolean debug) {
			MasterCardApiConfig.DEBUG = debug;
		}

		public static Boolean isDebug() {
			return MasterCardApiConfig.DEBUG;
		}
	}

}
