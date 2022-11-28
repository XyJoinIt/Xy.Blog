using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Core.GlobalConfigEntity
{
    public class JwtOption
    {

        /// <summary>
        /// //发行人Issuer
        /// </summary>
        public string Issuer { get; set; } = default!;

        /// <summary>
        /// 订阅人Audience
        /// </summary>
        public string Audience { get; set; } = default!;

        /// <summary>
        /// 秘密密钥
        /// </summary>
        public string SecretKey { get; set; } = default!;

        /// <summary>
        /// 过期时间 分钟
        /// </summary>
        public int Exp { get; set; } = default!;
    }
}
