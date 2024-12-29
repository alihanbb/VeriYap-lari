using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hafta9_10_Stack
{
    // Searching - search algoritmaları n a biraz daha detaylı bak araştır ve kodla
    /*
      30000 liste 1 öğrenciyi öğrenci no ile arama yapacağız.
      Dikkat!!! cleancode olarak değişken isimlendirmelerine dikkat et
      NOT :  Landa expression lara bir bak.
     */
    public class bplustree
    {
        int[] items = new int[1000];
        bplustree[] links = new bplustree[1000];
        public bplustree left;
        public bplustree right;
        public int data1;

        // harddiskte dosyadan veri okuyacağın zaman 4 kb olması gerekir.
        // primary index int tipinde işlem yapar
        int[] items1 = new int[497];
        int[] links1 = new int[497];
        int left1 = 0;
        int next1 ;
        int prev1 ;

        // mysql
        // range query bir bak
    }
    // bplus tree dosya kısmını sonra yap
    public class Block
    {
        public int data;
        public Block next;
        public Block prev;
    }
    public class Program
    {
        public string Hash;
        static int[] stack = new int[100];
        static int sp = -1;
        static void push(int data)
        {
            if (sp >= stack.Length) return;// stack alanımızdan fazla veri atanıp  stack'ın patlamaması için önlem aldık
            sp++;// sp-->stack point
            stack[sp] = data;
        }
        static int pop()
        {
            int data = stack[sp];
            sp--;
            return data;
        }
        static int stackcount()
        {
            return sp + 1;
        }
        static int peek()
        {
            int data = stack[sp];
            return data;
        }
        static int topla(int a, int b)
        {
            return a + b;
        }// lamda expression lar, delegate advanced ileri programlama 
        static int fark(int a, int b)
        {
            return a - b;
        }
        static int carp(int a, int b)
        {
            return a * b;
        }
        static int bolme(int a, int b)
        {
            return a / b;
        }
        static void ders1(int a, int b, int c, int d, int e, int[] f)
        {
            //ders2();
            // Console.WriteLine( "Ben metot 1");
            Console.WriteLine("ben metot {0}{1}", a, b);
        }
        //static void ders2()
        //{
        //    ders3();
        //    Console.WriteLine("Ben metot 2");

        //}
        //static void ders3()
        //{
        //    ders4();
        //    Console.WriteLine("Ben metot 3");
        //}
        //static void ders4()
        //{
        //    Console.WriteLine("Ben metot 4");
        //}
        static void directoryWrite(string path)
        {
            string[] direct = Directory.GetDirectories(path);
            Console.WriteLine(path);
            for (int i = 0; i<direct.Length; i++)
            {
                directoryWrite(direct[i]);
            }
        }
        
        static int[] Queue = new int[100];
        static int Front = 0;
        static int Rear = -1;
        static int QueueCount()
        {
            return Rear - Front + 1;
        }
        static void enqueue(int data)// stacktaki push'un karşılığı{-
        {
            Rear++;
            if (Rear >= Queue.Length)
            {
                // veri taşıma t 
                //int adt = 0;
                //Rear--;
                //int elemansayisi = QueueCount();

                for (int i = Front; i < Queue.Length; i++)
                {
                    Queue[i-Front] = Queue[i];
                   // adt++;  
                }
                Rear = Rear - Front;
                Front = 0;
                //Rear = elemansayisi;//adt; // veri taşıma işlemini gerçekleştirdik.
            }
            Queue[Rear % Queue.Length] = data; 
        }
        static Block FrontLl = null;
        static Block RealLl = null;
        static void enqueueLl(int data)
        {
            Block tmp = new Block();
            tmp.data = data;    
            if(RealLl == null)
            {
                RealLl = tmp;
                FrontLl = tmp;
            }
            else
            {
                RealLl.next = tmp;
                tmp.prev = RealLl;
                RealLl = tmp;
            }
        }
        static int dequeueLL()
        {
            int data = FrontLl.data;
            FrontLl = FrontLl.next; 
            if(FrontLl == null) { RealLl = null; }
            return data;
        }
        static int dequeue() // stacktaki pop karşılığı
        {
            int data  = Queue[Front% Queue.Length];
            Front++;
            return data;
            // yada return Queue[Front++]; yazıladabilir.
        }
        //ÖDEV : priority queue (öncelikli kuyruk) bunu kodla implemente et  EKLER İKEN      Sırala sort et
        /*
          ARAMA TEORİSİ
          Sequential Search ---> en ilkel arama yöntemi, hesaplama karmaşıklığı O(n)
          Binary Search --->   ikili arama, hesaplama karmaşıklığı log(n) Bu dizinin zorluğu diziyi sürekli yeni gelen elemanlardan dolayı, sürekli güncel tutmak zorundasın.
        Örnek: 1024 elemanlı bir dizide squentialda ortalama 512, binary de ise 10 dur.
          ÖDEV : Binary Search kodlanılacak
          Çok boyutlu ve sürekli dinamik olarak eleman eklenen dizilerde search yapamayız.
          B+ Tree  Data Structure bak
          Isam (Indexed sequential Access Method) ---> Cobol dilinde kullanılır. Complex , berbat bir yapıdır.
          B+Tree de 1 000 000 000 verilerek arama yapılan yapılarda arama süresi 3'tür.
          B+ tree b tree'den farklı olarak genelde alt blokların %70'i doludur.
          Indexed data 
          Hashing ---> en  hızlı search algoritması, fakat büyük verilerde kullanılması mümkün değil. Temelinde diziler vardır. Tüm mekanıznması dizilerden oluşur.
        x[45],  x[6], x[4644] bu elamanlarına erişmek için geçen süre aynı.
        Ogrno üzerine hash yapısı nasıl kurulur.
        Hash Function - kiritik noktamız ---> verinin, dizinin hangi indisine yazılacağını belirler.

        çakışmsyı az tutarsam dizinin eleman sayısını arrttırmam gerekecek bu na bağlı olarak da depolama alanaınnında arttırmam gerekir
        Düzgün bşr hash function seçmezseniz sistem patlar. Ne olursa olsun iyi bir function tasarlaman lazım. 
        Hash functionına  mod ekle.
        ÇÖZÜM: çakışan hashleri ayrı bir hash funciton' tabi tutup ve ayrı bir dizi de tutuyor olacağız.
        Algoritmik becerilerini geliştir.
        Dizilerin boyutu arttıkça hash yapısı karmaşıklaşır. bu karmaşıklığı çözmek için ise daha farklı function olarak kullanmamız gerekecek 
          
         */
        static Block[] hashLinked = new Block[100];
        static Block[] hashlink = new Block[100];   



        static int[] numara = new int [30000];
        static string[] ogrler = new string [30000];

        static int[] hash = new int[100];
        static int[] hashCtrl = new int[100];   
        // hash[20] = 20;
        // hachCtrl[20] =
        // 0 boş; 1 eleman var; 

        static int hashfunc (int data)
        {
            return data % hash.Length;
            // hash fonkdiyonlarında mutlaka mod olur.
            // 123456 = 1+2+3+4+5+6

        }
        static void delete(int data)
        {
            int indis = hashfunc(data);
            if(seacrh(data))
            {
                if (hash[indis]== data) hash[indis] = 0;
                else
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] == data) { hash[i] = 0;  break; }  
                }
                hashCtrl[indis]--;
            }
        }
        static bool seacrh(int data)
        {
            int indis = hashfunc(data);
            //if (hash[indis] == data)
            //    return true;
            //else return false;
            // yada bunu kullan
            if (hashCtrl[indis] ==0) return false;  

            //if (hash[indis]==0) return false;// ekleme olmamış!
            //if(hash[indis]==data) return true;
            for (int i = 0; i < hash.Length; i++)
            { 
                if (hash[indis] == data) return true;

            }
            //return false;

            return hash[indis] == data; 
        }
        static void HashAdd(int data)
        {
            int indis = hashfunc (data);
            if (hash[indis] == 0)
            { hash[indis] = data; hashCtrl[indis]++; }
            else if (hash[indis] != data)
            {
                //    for (int i = indis+1; i < hash.Length; i++)
                //    {
                //        if (hash[i] == 0)
                //            hash[i] = data;
                //        else if (hash[i] == data) return;//yada break;
                //    }

                for (int i = 0; i < hash.Length + indis; i++)
                {
                    int md = i % hash.Length;
                    if (hash[md] == 0)
                        hash[md] = data;
                    else if (hash[md] == data)
                        return;//yada break;
                }
            }
            hashCtrl[indis]++;
        }
        static bool searchLinked(int data)
        {
            int indis = hashfunc(data);
            Block t1 = hashLinked[indis];
            while (t1 != null)
            {
                if (t1.data == data) break;
                t1 = t1.next;
            }
            if (t1 == null) return false;
            else return true;
            //return !(t1 == null);

            //NOT HASHLERDE DİCTİONARY YAPILARINA BAK BUNUN LA İLE İLGİLİ BİR ÖRNEK KOD YAZ
            // DİİCTİONARY
        }
        static void HashLinkked(int data)
        {
            int indis = hashfunc(data);
            if (hashLinked[indis] != null)
            {
                Block t1 = hashLinked[indis];
                while(t1!=null)
                {
                    if (t1.data == data) break;
                    t1 = t1.next;   
                }
                if (t1 != null) return;
            }
            Block tmp = new Block();
            tmp.data = data;
            tmp.next = hashLinked[indis];
            if(hashLinked[indis]!=null) hashLinked[indis].prev = tmp;
            hashLinked[indis] = tmp;
        }

        static int[] BinaryTree = new int[100];
        static void TreeYaz(int[] bt, int inds)
        {
            if(inds>= bt.Length) return;
            Console.WriteLine(bt[inds]);

            TreeYaz(bt, inds * 2 + 1); // sol çocuk
            TreeYaz(bt, inds*2 + 2); // sag çocuk

        }// tehlikeli ve dikkatli  kullanılmalı
        static int ders1(int[] bt, int inds)//counter
        {
            if(inds>= bt.Length) return 0;
            if (bt[inds]==0) return 0;
            return 1 + ders1(bt, inds * 2 + 1) + ders1(bt, inds * 2 + 2);

            //******** 
            if(bt[inds] == 0)
            return 1 + ders1(bt, inds * 2 + 1) + ders1(bt, inds * 2 + 2);
            else
            return 0 + ders1(bt, inds * 2 + 1) + ders1(bt, inds * 2 + 2);
        }
        static int ders2(int[] bt,int inds, int search)// search
        {
            if(inds>= bt.Length) return 0;
            if (bt[inds] == search) return 1;
            return ders2(bt, inds * 2 + 1,search) + ders2(bt, inds * 2 + 2,search); 
        }
        static int ders3(int[] bt, int inds, int search) // binary search tree
        {
            if(inds>= bt.Length)return 1;
            if(bt[inds] == search)  return 0;
            if (bt[inds]<search) return ders3 (bt, inds*2 + 2,search);
            else
            {
                return ders3(bt, inds*2+1,search);
            }
        }
        static void ders4(int[] bt, int inds, int[] sonuc)// int ve diziler referans tipli değişkenlerdir.
        {// sol ve sağ eleman sayısı
            if(inds>= bt.Length) return;
            if (inds % 2 == 0) sonuc[0]++;
            else sonuc[1]++;    
            ders4(bt,inds*2+1, sonuc);
            ders4(bt,inds*2+2,sonuc);

        }
        static void ders5(int[] bt, int inds, int[] sonuc) // sol ve sağ en büyük eleman bulma 
        {
            if (inds >= bt.Length) return;
            if (inds % 2 == 0)
             { if (bt[inds] > sonuc[0]) sonuc[0] = bt[inds]; }
            else if (bt[inds] > sonuc[1]) sonuc[1]= bt[inds];

            ders4(bt, inds * 2 + 1, sonuc);
            ders4(bt, inds * 2 + 2, sonuc);

        }
        static int ders6(int[] bt, int inds, int derinlik) // derinlik bulma sorusu
        {
            if (inds >= bt.Length) return derinlik;
            if (bt[inds] == 0) return derinlik;
            int a =  ders6(bt, inds * 2 + 1, derinlik + 1);
            int b = ders6(bt, inds * 2 + 2, derinlik + 1);   
            if(a>b) return a;
            else return b;
        }
        static int ders7(int[] bt, int inds) // derinlik bulma 2. farklı çözüm yöntemi
        {
            if (inds >= bt.Length) return 0;
            if (bt[inds] == 0) return 0;
            int a = 1+ders7(bt, inds * 2 + 1);
            int b = 1+ders7(bt, inds * 2 + 2);
            if (a > b) return a;
            else return b;
        }
       
        static void ders8(int[] bt, int inds, int[] svy, int seviye)  // her derinlik seviyesinin eleman adedini bulalım.
        {
            if (inds >= bt.Length) return ;
            if (bt[inds] == 0) return ;
            svy[seviye]++;
            ders8(bt, inds * 2 + 1, svy, seviye + 1);
            ders8(bt, inds * 2 + 2, svy, seviye + 1);
        }
        static void ders9(int[] bt, int inds, int[] svy, int seviye)  // her derinlik seviyesindeki en büyük   elemanı bulalım.
        {
            if (inds >= bt.Length) return;
            if (bt[inds] == 0) return;
            if(svy[seviye] < bt[inds]) svy[seviye] = bt[inds];
            ders9(bt, inds * 2 + 1, svy, seviye + 1);
            ders9(bt, inds * 2 + 2, svy, seviye + 1);
        }
        static int ders10(int[] bt, int inds, int data)  // boş b tree 'ye eleman ekleme
        {
            if (inds >= bt.Length) return 0;

            if (bt[inds] == 0) { bt[inds] = data; return 1; }

            if (bt[inds] < data) { return ders10(bt, inds * 2 + 2, data); }
            else  return ders10(bt, inds * 2 + 1, data);    
        }
        //
        static int chck(int[] x, int[] y, int ind) { return 1; }
        static bplustree ders11(int[] bt, int ind, ref bplustree pbt)
        {
            if(ind>= bt.Length) return null;
            if (bt[ind] == 0) return null;
            bplustree tmp = new bplustree();
            tmp.data1 = bt[ind];
            if(pbt == null) pbt = tmp;
            pbt.left  = ders11(bt, ind*2+1,ref pbt);
            pbt.right = ders11(bt, ind*2+2 , ref pbt);
            return pbt;
        }

        static void Main(string[] args)
        {
            //binary tree
            int[] x = { 1, 2, 3, 4, 5, 6, 7 }; // peki dizi içerisinde birden fazla  aynı karakter olsa ne olurdu buna bir bak . 
            // 37- 39 dk aralarına bir bak.
            int[] y = { 50, 40, 70, 30, 45, 65, 80, 5 };
            int[] z = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            /*
                          50
                  40             70               =====> binary search tree
             30        45     65      80        
         5  
             */
            // btree'de soldaki  ve sağdaki en büyük çocuğu bul
            // bir ağacın derinliğini bul
            // tree llerde genellikle  recursive yapılarını bul
            // her derinliğin en büyük elamanını bulalım.
            Console.WriteLine(ders3(x,1,5));
            TreeYaz(x, 0);
            TreeYaz(x, 1);  
            TreeYaz(x, 2);
            Console.WriteLine(ders2(x,0,7));











            //hashing
            int indis = hashfunc(20);
            hash[indis] = 20;
            int data = 77;
            hash[hashfunc(data)] = data;   // bu daha iyi
            //algoritma automata kodlama kullanılacak

            hash[hashfunc(121)] = 121;
            // COLLİSİOM durumu meydana geldi
            hash[hashfunc(21)] = 21;



            // Burada dictionary  yapısı   buradaki key  olur. Buna bağlı olarak value değerini biz sonrasında hallederiz.
            Block tmp = new Block ();
            tmp.data = 2100;
            if (hashlink[3] == null)
            {
                hashlink[3] = tmp;
            }
            else
            {
                tmp.next = hashlink[3];
                hashlink[3].prev = tmp;
            }

            int bulundu = 0;
            for (int i = 0; i < 30000; i++)
            {
                if (numara[i] == 200205004) { bulundu = 1; break; } // buradaki sıkıntılı durumu sonra düzelt
            }







            enqueue(1); 
            enqueue(2);
            enqueue(3); 
            enqueue(4);
            enqueue(5);
            Console.WriteLine(dequeue());
            Console.WriteLine(dequeue());
            Console.WriteLine(dequeue());
            Console.WriteLine(dequeue());
            Console.WriteLine(dequeue());

            for (int i = 0; i < 35; i++)
            {
                enqueue(i);
            }
            for (int i = 0; i < 35; i++)
            {
                Console.WriteLine(dequeue());
            }

            //stackler
            /*
             * recursive ++
             Hem donanım hemde yazılım dünyasında kullanılır.
             Ayrıca matematiksel formullerin hesaplanmasında da kullanılır.
             */
            //int a = 1;
            //int b = 2;
            //int c = 3;
            //a = a+b*c/(a+b+c);
            // postfix,infix,prefix
            //oyun yazılımlarında da kullanılır.
            // ErP stock takibi için de kullanılır.
            // metodlar da da stacklar kullanılır.
            // donanımın interrupt kısmında mouse hareketinde de kullanılıyor.

            // List tarzı içerisinde birden fazla veri - eleman  
            // dizi-linked list oluşturarak kullanılırız.
            // stack yapısı : son gelenin ilk çıktığı yer LİFO(last in first out) yada LİFO
            // eleman ekleme çkarma
            /*
             bilal-emre-bora-adnan
             adnan
             bora 
             emre
             bilal
             */
            // stack yapısı kuyruk yapısının tersidir.
            // metotlarda stack yapısını kullanırız.
            // stack push vepop olmak üzere iki komut kullanır.
            // push ile veri aktarma , pop ile veri çekme yada alma işlemi yaparız
            //int[] x = {1,2,3,5,6,7};    
            //ders1 (1,2,3,4,5,x);
            //Console.WriteLine("tüm metolar çağrıldı");

            //push(10);
            //push(20);
            //push(30);
            //push(40);
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());
            // stack boşken stacktan eleman alamazsın yani pop edemezsin

            for (int i = 0; i < 100; i++)
            {
                push(i);
            }
            //stack taşması stack overflow denir. Sebebi aşağıda
            //  push(100); -->> stack 100 elemanlı tanımladığı için 101. elemanı ekleyemeyiz. bu yüzden push edemeyiz.
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(pop());
            }


            /*
             ( [ { } ] )
             ((([[{   }]])))
             (({[)
             ()
             ([])
             rtyrogrgrgrtr(gjjy(jy[jttj{tu}]jyjy)yjyj7)
             */
            string st = "r()()(()[]()[][][])";
            string p = "([{}])";
            int hata = 0;
            for (int i = 0; i < st.Length; i++)
            {
                int indis1 = p.IndexOf(st[i]); // index of metodu, bir karakterin yada bir alt dizgenin string içerisinde ilk kez geçtiği konumu(indeksi) bulmak için kullanılır.
                if (indis1 == -1) continue;
                if (indis1 <= 2)
                    push(p[indis1 + 3]);
                else
                {
                    if (stackcount() == 0) { hata = 1; break; }
                    char ch = (char)pop();
                    if (st[i] != ch) { hata = 1; break; }
                }
            }
            if (hata == 0)
            {
                Console.WriteLine("Dogru");
            }
            else Console.WriteLine("Hatalı");


            // A/(A-B*C/F-G)4H*C  ---> AABC*F/-G-/HC*+
            // OPERATOR >  STACKTAKİ OPERATOR İSE PUSH EDİLECEK
            // OPERATOR <= STACKTAKİ OPERATOR İSE POP EDİLECEK
            string postfix = "";
            string infix = "a+b*c/d-f+h";
            string variable = "abcdefgh";
            int[] values = { 1, 2, 3, 1, 0, 5, 0, 6 };// değişkenlere değer atadık
            string op = "$+-*/()";
            int[] oncelik = { 0, 2, 2, 3, 3, 1, 1 };// burada da operatörler için işlem önceliği belirledik.

            postfix = "abc*d/+f-h+";
            for (int i = 0; i < postfix.Length; i++)
            {
                if (op.IndexOf(postfix[i]) == -1)
                {
                    int indis2 = variable.IndexOf(postfix[i]);
                    push(values[indis2]);
                    continue;
                }
                int b = pop();
                int a = pop();
                int c = 0;
                if (postfix[i] == '+') c = topla(a, b);
                if (postfix[i] == '-') c = fark(a, b);
                if (postfix[i] == '*') c = carp(a, b);
                if (postfix[i] == '/') c = bolme(a, b);
                push(c);
            }
            Console.WriteLine(pop());
      

            postfix = "";
            push('$');
            for (int i = 0; i < infix.Length; i++)
            {
                int indis3 = op.IndexOf(infix[i]);
                if (indis3 == -1) { postfix = postfix + infix[i]; continue; }
                if (infix[i] == '(') { push(infix[i]); continue; }
                if (infix[i] == ')')
                {
                    while ((char)peek() != '(')
                    {
                        postfix = postfix + (char)pop();
                    }
                    pop(); // sol paratnez staktan alındı
                    continue;
                }

                if (oncelik[indis3] > oncelik[op.IndexOf((char)peek())]) // STACK taki veriyi pop etmeden bakmak için peek komutunu kullanırız.
                { push(infix[i]); }
                else
                {
                    while (oncelik[indis] <= oncelik[op.IndexOf((char)peek())])
                    {
                        postfix = postfix + (char)pop();
                    }
                    push(infix[i]);
                }
            }
            while (stackcount() > 1) { postfix = postfix + (char)pop(); }
            Console.WriteLine(infix);
            Console.WriteLine(postfix);
            Console.WriteLine();
            // verilen bir stringin polindromik  olup olmadığını stacklar yardımı ie bulunuz.
            string metin = "num";
            int hata1 = 0;
            for (int i = 0; i < metin.Length; i++)
            {
                push(metin[i]); 
            }
            for (int i = 0;i < metin.Length; i++)
            {
                if (pop() != metin[i]) { hata1 = 1; break; }

            }
            if(hata == 0 ) Console.WriteLine("polindromik");
            else Console.WriteLine("polindromik değil");
            /*
             en*boy*yukseklik
             enboyyukseklık**
             en$boy$yukseklik$**  $ dolar koymadan olmaz. dolara kadar en bul son sonra dolara kadar boy bul gibi gibi gitn
              */

            // ödev-sınavda çıkabilir:  a*b/c-f 
            // en* yukseklik-hacim/alan + elemansayisi

            string path = @"c:\windows";
            Stack<string> st1 = new Stack<string>();
            st1.Push(path);
            while(st1.Count > 0)
            {
                path = st1.Pop();   

                string[] direct = Directory.GetDirectories(path);

                Console.WriteLine(path);
                foreach (string item in direct)
                {
                    st1.Push(item);
                }
                // foreach yerine aşağıdaki for ilede kullanılabilir.
                //for (int i = 0; i < direct.Length; i++)
                //{
                //    st1.Push(direct[i]);
                //}


                //ÖDEV:
                // bu soruda windows sürücüsünde yer alan alt dizinlerin derinliğini bul.
                // recursive ile yukarıdaki soruyu çöz.


            }

        }
        // SINAVDA BTREELERİ ÇOK BOYULU DİZİ OLUŞTURARAK çÖZÜLEN BİR PROBLEM SORULACAK
    }   
}
