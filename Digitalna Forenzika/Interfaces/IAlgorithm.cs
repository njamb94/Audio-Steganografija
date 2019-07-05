using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalna_Forenzika.Interfaces
{
	public interface IAlgorithm
	{
		T Encrypt<T>();
		T Decrypt<T>();
	}
}
