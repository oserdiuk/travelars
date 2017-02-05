using GoogleApiService.Engine;
using GoogleApiService.Entities.Translate.Translate.Request;
using GoogleApiService.Entities.Translate.Translate.Response;

namespace GoogleApiService
{
    /// <summary>
    /// With Google Translate, you can dynamically translate text between thousands of language pairs.
    /// The Google Translate API lets websites and programs integrate with Google Translate programmatically
    /// Documentation: https://cloud.google.com/translate/v2/getting_started
    /// </summary>
    public class GoogleTranslate
    {
        /// <summary>
        /// This document details the background knowledge that you need to use the Google Translate API v2.
        /// </summary>
        public static EngineFacade<TranslateRequest, TranslateResponse> Translate => EngineFacade<TranslateRequest, TranslateResponse>.Instance;
    }
}