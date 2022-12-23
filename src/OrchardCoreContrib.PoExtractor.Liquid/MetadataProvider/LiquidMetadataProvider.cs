﻿using System.IO;

namespace OrchardCoreContrib.PoExtractor.Liquid.MetadataProviders
{
    /// <summary>
    /// Provides metadata for .liquid files
    /// </summary>
    public class LiquidMetadataProvider : IMetadataProvider<LiquidExpressionContext>
    {
        private readonly string _basePath;

        /// <summary>
        /// Creates a new instance of a <see cref="LiquidMetadataProvider"/>.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public LiquidMetadataProvider(string basePath)
        {
            _basePath = basePath;
        }

        /// <inheritdoc/>
        public string GetContext(LiquidExpressionContext expressionContext)
        {
            var path = expressionContext.FilePath.TrimStart(_basePath);

            return path.Replace(Path.DirectorySeparatorChar, '.').Replace(".liquid", string.Empty);
        }

        /// <inheritdoc/>
        public LocalizableStringLocation GetLocation(LiquidExpressionContext expressionContext)
            => new() { SourceFile = expressionContext.FilePath.TrimStart(_basePath) };
    }
}
