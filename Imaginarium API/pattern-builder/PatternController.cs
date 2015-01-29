using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Imaginarium_API.pattern_builder
{
    public class PatternController : ApiController
    {
        [HttpGet]
        [Route("pattern-builder/patterns")]
        public IEnumerable<DataTransferObjects.PatternBuilder.Pattern> GetAll()
        {
            return new List<DataTransferObjects.PatternBuilder.Pattern>();
        }

        [HttpGet]
        [Route("pattern-builder/pattern/{patternId}")]
        public DataTransferObjects.PatternBuilder.Pattern Get(Guid patternId)
        {
            return new DataTransferObjects.PatternBuilder.Pattern();
        }

        [HttpPost]
        [Route("pattern-builder/pattern")]
        public DataTransferObjects.PatternBuilder.Pattern Post([FromBody] DataTransferObjects.PatternBuilder.Pattern pattern)
        {
            return pattern;
        }

        [HttpPut]
        [Route("pattern-builder/pattern")]
        public DataTransferObjects.PatternBuilder.Pattern Put([FromBody] DataTransferObjects.PatternBuilder.Pattern pattern)
        {
            return pattern;
        }

        [HttpDelete]
        [Route("pattern-builder/pattern/{patternId}")]
        public void Delete(Guid patternId)
        {

        }
    }
}
