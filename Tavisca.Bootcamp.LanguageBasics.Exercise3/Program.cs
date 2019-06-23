using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static int maxval(int[] prob,List<int> ind)
        { int m=prob[ind[0]];
          if(ind.Count!=1)
          {foreach(int i in ind)
          { if(m<prob[i])
            {
                m=prob[i];
            }
          }
          }
          return m;
        }
        public static int minval(int[] prob,List<int> ind)
        {int m=prob[ind[0]];
          if(ind.Count!=1)
          {foreach(int i in ind)
          { if(m>prob[i])
            {
                m=prob[i];
            }
          }
          }
          return m;

         }

         public static List<int> Indexofall(int[] prob,List<int> ind,int val)
         { 
             List<int> resindex=new List<int>();
             foreach(int x in ind)
             { 
                 if(prob[x]==val)
                 { 
                    resindex.Add(x);
                 }
             }
             return resindex;

         }

          

        

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int l1=protein.Length;
            int[] cal=new int[l1];
            for(int i=0;i<l1;i++)
            { cal[i]=protein[i]*5 + carbs[i]*5 + fat[i]*9;}
            /* int maxcarb=carbs.Max();
            //int maxcarbindex=carbs.ToList().IndexOf(maxcarb);
            int maxprotein=protein.Max();
            //int maxproteinindex=protein.ToList().IndexOf(maxprotein);
            int maxfat=fat.Max();
            //int maxfatindex=fat.ToList().IndexOf(maxfat);
            int maxcal=cal.Max();
            //int maxcalindex=cal.ToList().IndexOf(maxcal);*/
            int[] res=new int[dietPlans.Length];
            
            for(int i=0;i<dietPlans.Length;i++)
            { List<int> ind=new List<int>();
              for(int v=0;v<l1;v++)
              { 
                  ind.Add(v);
              }
              int maxv=0;
              int minv=0;
              char[] arr=dietPlans[i].ToCharArray();
              if(arr.Length==0)
              {
                  res[i]=0;
                  continue;
              }
              for(int j=0;j<arr.Length;j++)
              { switch(arr[j])
                {
                    case 'C':maxv=maxval(carbs,ind);
                             ind=Indexofall(carbs,ind,maxv);
                             break;
                    case 'c':minv=minval(carbs,ind);
                             ind=Indexofall(carbs,ind,minv);
                             break;
                    case 'P':maxv=maxval(protein,ind);
                             ind=Indexofall(protein,ind,maxv);
                             break;
                    case 'p':minv=minval(protein,ind);
                             ind=Indexofall(protein,ind,minv);
                             break;
                    case 'F':maxv=maxval(fat,ind);
                             ind=Indexofall(fat,ind,maxv);
                             break;
                    case 'f':minv=minval(fat,ind);
                             ind=Indexofall(fat,ind,minv);
                             break;
                    case 'T':maxv=maxval(cal,ind);
                             ind=Indexofall(cal,ind,maxv);
                             break;
                    case 't':minv=minval(cal,ind);
                             ind=Indexofall(cal,ind,minv);
                             break;
                }
                if(ind.Count==1)
                {
                     res[i]=ind[0];
                     break;
                }
                
              }
              res[i]=ind[0];
               
                            
            }
            /* for(int i=0;i<res.Length;i++)
            { 
                Console.Write(res[i]+" ");
            }*/


            
        
            //throw new NotImplementedException();
           return res; 
        }
    }
}
