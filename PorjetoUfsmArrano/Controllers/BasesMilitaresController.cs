﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Rotativa;
using Rotativa.Options;
using RazorPDF;
using PorjetoUfsmArrano.Models;

namespace PorjetoUfsmArrano.Controllers
{
    public class BasesMilitaresController : Controller
    {
        private BasesMilitaresContext db = new BasesMilitaresContext();

        // GET: BasesMilitares
        public ActionResult Index()
        {
            if (!new HomeController().Master(this))
            {
                int idbasemilitar = new HomeController().Base(this);
                var consultar = from usuario in db.BasesMilitares
                                join c in db.BasesMilitares on usuario.id_BasesMilitares equals c.id_BasesMilitares
                                where c.id_BasesMilitares == idbasemilitar
                                select usuario;
                return RedirectToAction("SemPermissao", "Home");
            }
            return View(db.BasesMilitares.ToList());
        }

        // GET: BasesMilitares/Details/5
        public ActionResult Detalhes(int? id)
        {
            //if (!new HomeController().Master(this))
            //{
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BasesMilitares basesMilitares = db.BasesMilitares.Find(id);
                if (basesMilitares == null)
                {
                    return HttpNotFound();
                }
                return View(basesMilitares);
            }
        //    else
        //        return View(db.BasesMilitares.ToList());
        //}
        // GET: BasesMilitares/Create
        public ActionResult Cadastrar()
        {
            //if (!new HomeController().Master(this))
            //{
            return View();
            }
        //    else
        //        return View(db.BasesMilitares.ToList());
        //}

        // POST: BasesMilitares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id_BasesMilitares,nome,descricao,TipoBase,Tipologradouro,Rua,endereco,complemento,numero,bairro,cidade,uf,email,nome_contato,pais,logo,latlon,Cep,Telefone,NomeFantasia")] BasesMilitares basesMilitares, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //if (!new HomeController().Master(this)) { 
                if (file != null)
                {
                    byte[] PhotoArray = new Byte[file.ContentLength];
                    System.IO.Stream PhotoStream = file.InputStream;
                    PhotoStream.Read(PhotoArray, 0, file.ContentLength);

                     basesMilitares.logo = PhotoArray;
                }
                else
                {
                    string x = "FFD8FFE000104A46494600010101004800480000FFDB0043000202020202020202020202020202030403020203040504040404040506050505050505060607070807070609090A0A09090C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFDB004301030303050405090606090D0B090B0D0F0E0E0E0E0F0F0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC2001108015E023403011100021101031101FFC4001C0001000301010101010000000000000000000506070403020108FFC40014010100000000000000000000000000000000FFDA000C03010002100310000001FEFE00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000007C90C4311A721F27D1D4489324D1F60000000000000000000000000000000000000000000E72A255CE70000003DCB316E3AC0000000000000000000000000000000000000001F8558A49E27D13A4E92A761EA799C645904409F07A1732DC7E800000000000000000000000000000000000007919F15F3E8B516F3AC000000E72A2548F826CD10F70000000000000000000000000000000000003C4CD8883BCD0C9400000000023CCF08C248D30E800000000000000000000000000000000000FC33620C17B2D600000000001E66744112C69A7D800000000000000000000000000000000029A52C923F48D2FE59800000000003CCCD0882DA5E4000000000000000000000000000000000E032A3E8D4CF7334234BF96600000000000E532A3C4D40950000000000000000000000000000000019E95B2EE5BC1CE6684697F2CC0000033B38C1D868801572824E9A480000000000000000000000000000000729929EC6B47A102558992B44697E23C8F0000429E40F5268B21633E4CA0E23562400000000000000000000000000000001542885B8BC0284568B596633D234BA958380000000163343053CA49732E60000000000000000000000000000000CE08034E260142204D68FD39CCD08D2EA461D2709067C80002C668608F329260D380000000000000000000000000000001929CA6C27D8284558FA3F41722BA4697F3CCFA254CDCE40002C66860FC3213E4D80FD000000000000000000000000000001F2636771AC00508AB0001A6146234BA958240B599A80016334300CB88A35D3A400000000000000000000000000000781901286A401422AC003E8D54AE95D234BA95834333539C0058CD0C033520CD64ED000000000000000000000000000001E263E499A980508AB000F634D32C2EA56C8F2EA4F99B9C4002C6686019A1086B476000000000000000000000000000000FC31D3D8D740284558000D48CF0E12EA5688F34129670800B19A180654471B09EA000000000000000000000000000000656469AE9D20A1156000268BD94622CBE94B23CBB15638402C66860F831E3A4D6C0000000000000000000000000000001422AC68658C1422AC0000932DC481C27395523CBB15638416334304219A16134500000000000000000000000000000004019C1603460510AA00000003F4BA95A23CBB156384B21A1028255CBF96700000000000000000000000000000007C9921CE6AC779CA44800000007E92866A479783B4943B0E53273F4D6CF600000000000000000000000000000000A81482C068C00000000001CC666479A11630504AB9702EC000000000000000000000000000000003CCCACE13402CC00000000001CC666479A11EA66E749AB1EE000000000000000000000000000000000431999F46964C000000000007319991E7A1E468E4F80000000000000000000000000000000000550A21E86884F00000000000574CEC1742E4000000000000000000000000000000000000544A39FA5B8B99E800000001F0540A69F25C4BA80000000000000000000000000000000000000578A01E27516E2CA74800007815B2A2711E85ECB38000000000000000000000000000000000000001C8520AD83F495254ED3D0F338C8B224F904F9793B800000000000000000000000000000000000000000471572BA7200000749602D449800000000000000000000000000000000000000000000FC3888D390F33D0EA244EF3F400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003E4F03A4000000000000000000000000000000000000000000000000000C58B09673A0F83B08C3BC8E2CA0CC8EC2DA451DE7B1D056CB49C2461642B44E9E2439247E92E0000000000000000000000000000000C9CF22F0660789642DA66C4A9AA1D2530EC33E278F4220D10A01F8731D67D8230FA2CA471C46BC0000000000000000000000000000000A1926540E52E2570D50CB0EC2F4769413B4AE9663D8A99E65B8A71C4092278902A65CC8C2BE6A60000000000000000000000000000000AF9CA5A488380972408F3E8EB3EC863E8F73DCFD39CF62089729E53CDA4AF1227B9D4799E2480000000000000000000000000000000000000000000000394FB3DC000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFC4002E1000020202000404060202030000000000030401020005101213500611153414203031333521364060237080FFDA0008010100010502FF00C75331184D82C3CBEDB2DB366725E6A73E31AC875A8CAEC9A8CA6DA707B15AF913168EF4428C506DA4E10A42CFD1A108390ED2D18230CD1DDD9D95699725C96C889B48F5CC1329AA14655256B90214672D724429CB26ADB2FAB0CE135AC5326B6ACE56F6A4ADB289CFBF74BDEB4AB6F58FC2226657D65AD8208831F44821960FAB9CB566B38ABB75E464A16BDC6F7A8EADB7666D8BAC462CBAA25E3EA9D61310CAA45A71666EB5864A169DBFED8EB72C5F86B9AA4D7EBDAB5BD5C4E579C51A95AF13168EDDB26B82AB599232B5D6BFDB1277ABFE05AB16871595AF9AD6B967B6B26800A666D34ACDECB82AB8C83A168CAD75AFF6C49DEAFF00806154C328EC2BFDB143FC407B66C8FCE5CD62FE51C083A168CAD75AFF006C49DEAFD161C6687F8E6B3E39AC5DC66E7E3B25F9C79AF3F48FDACC4E90A67CE4439292B58A571D73E1A3D49AC035472ACAD75AFF006C49DEB430D3ABDFD49ACF526B3D49ACF526B3D49ACF526B2F7925B852F23B7A935893B2C4E7DF181740D8B17AC0ED5B52790F3542F3B70DAFE6AD66F68D4DF3A3370B2B5D6BFDB0071BA3617BAF7FA5ABF73C36A2FE33524ED7B2BF33388D3A6B70DAFE604F91F810742D195AEB5FED8038DD1FA631CFE924CBEB99A64C4D67E6D5FB9E0D53A8BE217E46BB5316E73C479CC472C70DAFE6CE69CE6B6735B16668D5195AEB5FED893BD5C61D3AF716D056C32E16A870D804F9757EE7892BC84A5B92FDA67F8E0B479B1C76BF9BE50D6585195AEB5FED8038DD1B0BDD7BA2DC82EF020C1F9757EE78BD1E4D60A7CC5DA09F8F12F75C76BF9BE488E6935BA2BACCD1AA32B5D6BFDB0071BA3617BAF74EFD458B5E42FC9ABF73C763EEF17F6FDA2FFCD313F75C76BF9BE41CF2DDC8E65716668D5195ACB5FED803D1D1AA1900599F363E4D5FB9E3B0F778BFE0ED368E5B06DCA6E3B5FCDF2AA483AEC82572E2EC0DC1B2B5D6BC4F9624EF5E1805D7BFC9ABF73C5BB7333948E5A76972BC8CE0AFD4170DAFE6F9526BE1EE6089A1975EC0F3A65890C5DA032B5D6BC4F9604C3786705D7BF1D5FB9E169E5899E690579CDDAB6B4F22E6B09CCBF0DAFE6F9976CABE0F680B67C6AB97D9AF5C13427A195AEB5E27CB0261BC3382EBDF86AFDCF0D813A6B66B29CCC76AD88F9D7CD697A67E1B68FF0097E9AEC0DC1B2B5D6BC4F9604C3786705D7BE6AFDC70DA1798B9AB1F287B54C44C187212C4F962C6EB870A119ABE9AAE7A6AB9E9AAE7A6AB9E9AAE7A6AB9E9AAE7A6AB9E9AAE7A6AB9E9AAE7A6AD840D0A3656BAD789F2C01C4ED3D355C080408C312023B5A6F6A52497A56294ED7B4079C66BD9E893EB945435195AEB5E27CB1277ADC764C73DF3560FE7B65AB16AB0195CB9AF6FAB5FAE5150D4656BAD789F2C49DEB63CD742981158C41D2A2A76D716F881CC4C4D6D34B28DD59AFD728A86A32B5D6BC4F965EF625B1157A14EDEFA7CFC297B0ECA3B463FC07CC0A8F86BD3EE4F23CDC56D94C656D5BC7D3998AC33B3C99999C490F3EE8DA153E5C7715B04628643B4ACE50A32FD0B9283836D075C33053CE56B6BD94D7C0BBB14233D4FAD28F8C4CC651E6A995DB13236D4CF550E4EDA996DB132EFB57C999B4F05F5E62E05712F1DE0CA84F85D55E308030BE850252E0B5659C0A80077EBAC0BE5B58ACE4EA459E934CF491646B168CA2ABD3FDF667CB2A615E7FD1402BF885B278635F68D6AA74D76B609A78AEC52725869756AC6DB5CADFE354E8036FAD649C3C4682F6574082E15A5D560B4DD6AEE46B629278AB8ABB531C2BD3D7B53E6320CB465D5538A6EB577AD6D17A9775AB0DC270B34B36B54DEB7AA9232FA69C2AFA8EC76A3EA7629B53B8DD2700D98194754E6AA336CE6B26DE299F3443A6D6887A8D72E67FC448AABAA2B4DC59E20FD469BF5774C2EF89777AD4A9ADD46B13BA6B8A897895EAA765EFB1F0FCC785EF9AA5C7B76BC428262436CDDD6D2ACEF86D50EACEB5778EAA273C47B5D5A15D6E8F5AA192908D1F12F6A53C43AF62AC6E35A11E81225B5DA56145AAC3DA65ABE2BF679A4FDA78A3F5ABFB7CF109C31ADD21C37D783FB56F7F55A6FD5DBFB57897F27AA6A570F86AF046358D0B4ACEF76CA36A6D95231A54DFD4B410B9ACBB36FED5B5FD6F87FF50EFF0066ED47D5EBD991693561B632826E6074DAC04B0AAED5704AAE1B9D70B34888AC61F5E93375D04D5B42ABC1CA219C631D034F855FAE5088F40E9B58BDC2AAEBD9FD9EA61875A5B6031D2063369B587B2C826A67C2AFD720E85A04225C76557B9FBF5C212E5063147FDE3FFFC400141101000000000000000000000000000000B0FFDA0008010301013F01434FFFC400141101000000000000000000000000000000B0FFDA0008010201013F01434FFFC40048100001020205050C0804050207000000000102030011041221315110223241911314202333425052617181C10562727382A1B1D13040B2E1245392C2F060A263708093D2D3F1FFDA0008010100063F02FF00A3A993218C69D73826D8E2DAF1518B0A13DC3EF1CB1F9472CB8E5951694ABBC7DA33DA1DE931A45B3EB44D241188E9BACE282444984CBD757DA26E2D4AFC29B6B524F6449F4D6F585F136D415D3050C496AEBEA8ACB5151C7248024E0226406C7AD19EB5AFBAC8B1949EFB7EB1636D8F08B845ADA0F845ACA3C2CFA4662968F9C66C9C1D9125029381C9590A2950D620229161FE67DE263A50A966AA45E60A119AD7D724809937080A7CD41D417C49B404F6FE149C40508AD4733FF867EF052A05245E0E4AA73DAD69C3BA02D06693D2456B324A6F3183634539248167397A846689AF5ACDFF008D258B752F5C675A83A2BC934DA93A6880B41983D21331553C92747B7B7286080858D1F5BF2052A01493788AC99A9A3AF0C98B6AD34C0524CC1B8F47EF741F787CB255162469AA246D41D05E4DC9D3C6EA3D6FC814A84C1BC462DAB40F964DEEB39AAE4FBF0E8E539AF9A3B60A94664DE61284DAA55820207C4713050B1306246D41D05E4DC9D3C6EA3D6FC829B55C75C29B55E9C815CF162FBFA37721A2D7D721A42AF363794A16260C48DA83A0BC9B93A78DD47ADF82EA52E9094A8C8472C7E51CB1F9434953A4A54A131C0DD93A4DE9776400E83B9A7CBA316E1E68824DE6F843639C60253604D832252800B8AC7545E8D9068F4902B1D138C48DA83A0BC9B93864EF3558C555144B9AA95F17A3645E8D917A3645E8D917A3645E8D90A5AAF5199CA95A6F49988BD1B20B6E001604C11AF248EB85B7A868F7646D7AC8CEEFE8B437D7333E1916F1E6E6A72B7EC79C2502F5190F18E584FBA372A410EFAD1236A0E82F26F7A4729CD5631555773558FE1FC072B6F619AAC8EB5F10F3E8B23A800F3C8DE2ACE3E395BF63CE1926C016999F1CA50B1306246D41D05E4DEF48E539AAC608152AEA598E5511604B9ECC488208BC1E1FC072BA9EC98F0C8DFAD9A7C7A2DD562A300630122E160CADFB1E792F31798D231BDA93A5CD563FBC48DA83A0BC9B93A78DD47AD1554CA65CD563127125AEDBC45B2F51C105B5F81C785F01E0388EAA8884ABAA41E8C647AE380DFB1E7C248A4E7571FF00C891B507417937BD2394E6AB18AAABB9AAC6021478A57CBB609E7B76A785F01E03DDF3DB91B38A4744AFD93919EFE037EC79F040C6C8594F3119B1BDA93A5CD563FBC48DA83A0BC9BDE91CA73558C5555DCD5630D13848F8590E23AAA2383F01E02FB87D3231EED3F4E895F71C8CFB5C06FD8F3E0A15D55030F7B33D9937B526D51D1563FBC5536A4E82F1C9BDE91CA73558C06C99C89B7C61E3EB9E0FC0780E764BE9918F769FA74514E0650D2B050E037EC79F0906FB2AAC42906EE61ECC9BDA93A7CD563FBC5555A93A0BC6262C22E31B9B864F6A38C555FC2AC783F01E03C7D696CC894E025D14F0F5A7B6DC8DAFAC9072B7EC79F0B3B935E97DE04ED17A1622C4EEA9C53F68D0727DD05BA5B4A182CD915556A4E82F1898B08B8C6F7A472BCD57988A8BF8558F03E0394A8DC9133049BCDB0D27150E8B439D74FD3254D6D99656FD8F3E1E699A35A0DD19E14D9DA23964C66D670EC8530F24249D08AAAB5274178C4C5845C637BD2395E6ABCC4545FC2AC72FC072AF15E68C95B53627E5D1655ADB35B2553A2ED9E3AB2B47555FC4DED49D3E6AB1FDE2AAAD49D05E3131611718DEF48E579AAF311517F0AB1C87B1072A5A17377F79C8A735B87E43A2C8371BE16D9E69898BC425CD7CEEFC955C4D61172F6C5CBDB172F6C5CBDB172F6C5CBDB172F6C5CBDB172F6C5CBDB172F6C73F6C6E6E670C75C5555A93A0BC6262C22E31B85207182E38C5CBDB126D329DF914E2B9B0A52AF519984A137A8C842502E4890E8C0FA79B62F2545726E7C8FE40A16260C5555A93A0BC6262C22E31B9B963A3FDD977149CD6F4BBF229F56AB11E7D1A52AB42AC2214D9F84E2326E4B3C622E388FC8142C4C18AAAB5274178C4C5845C637372C747FBA2AA7955DDD9DB912DA6F5425B4DC9E8EB3944E81F2891B08BC40524C942E31A83A9D24F9FE40A16260C5555A93A0BC6262C22E3056B35946F392B2871ABBFB061D21BB3433F9E9C720520D550B8C55566BB863DDF902DAC575AB453876E50FBA3DDA7CFA48BCC8CEE7A31CA1148B47F33EF15904292758FC49A88005E4C1451FF00EEFDA264CC9BCE40EBE3D86FEFD28568921DF918A8B494A8649B6B29C4449E4D5F593744DB5A55DDF8135AD291DB126535CF58D8238C59382756409402A51B84071D929CD4350E96AAE2678189B5C6A3E79660C8C72A543055B19ED215DD645ACA878C726E7CA2C695B6335A40EFB7ED1CA551EAD913249389CB35F148C4DFB224DA7BD5ACF4CE7A2DEB8BE26CAC287555618E31B527B757E0716DA95DB1C6A820602D319A89ABAE6D3D3D9CD20F6C58169EE3F78B1C7239656C8B5D722DAEAEF3F68CD651F5FF005ECCD8224875B51C01FF00435295497DC450E8CA93747478CBE91C5AA90D2B52A7382C3EF9A449677370CF47C63F89A421B26E4DE7608951A908715D4B8EC301748752D2546409C63737A9484AF5A44D52EF94E37CEF86B7BFF367646E2CD292A70DC920A67DD3195FA790ADF0DA509499D92AE05DE30CD31015BB521BE32DB2F87182FB6975A159C41D423724D31BAF75B3036912895269086C9E6DE76082BA33C9740D2C47818DD5F712D3639C625BEC7F4AFED01C6969710AD15A6D100D25F4353B81BCF8082A14C6A42F9CD276184AD2669509A4F64545D2D1585F54157E90637461C43A8EB2637BA9E425E956A870BE373DF8DD6C6DABFD52940349A421B9DC2F3B0413457D2ED5D2171D87A2DDA57A21D4D57AD5B065E7644E9BE8D0A6D3A4B4CC7CC5610ED35A9C994A8B8D9BC1489CA1DA5FA4DE4B94E79649AE852AA8ECB088A352FD18E2534B65CCEA8852263B6C114538BBFDA6373DEADBB3D271C15947C63D20C3E14E334274EE4C939B3AC44CEC86A934765BA3BA87409B62AE38436B37A9209F1C94BF83F5A6285EEE296D3E096C212A29065392110F38D519965C66A942D0996B02D86694F329A4BF484D6716F67FD614C51C5465E6AD6F55D3FA883BFAA6F7490A358C84E0B48A0EEE9BB8B647ED1E916935C3287125A42AF15AB7DA299E91A62776485D461A3A23C3BA0BCD519969C0B480A40AB7F7450D0DAAA2A9286D055EAD5B612CA56D2ECCF5A99512AEFCD875BA02E743A5227564400A027718430F56DCD4D02A02C9C84E2905BA2B2D2D945642D2246CED866974868525E7660977380092520007BA28A9A32434DD21A9ADB175B5BFF1E8B1BA39BD5DD685DDFD50A51A530F59C9B642C9ECB229BBA0DCD14F9A5B1D92227F3873D1FE904B2CD21959929C02D1DE62B2D7445608404A8FCA28DEFBFB4E4F4E7BE3FAD503DF27E8618F769FA64A4B05E683CAA852CD6158E78D5145690F34A750DE7B6142B0EF114DF723F4A2299EC8FD42285EEE1BF73FDA63D185EAC6861CE3E5E1E5380534AA306C0CD6DB94FF00A447A5DC1301C710A00F695C532814D9B482BACCB92247F860D1E8A56F1AC952DC093546D8A138D0ACBA321B591EAD5B612BFE0DA725C634BAA920F8C268F462C2DF2099B60484BD686FDCFF00698A77B957D2289F1FEB547A37DCFF00ECE8B9BB4468A8DEA19A7689456450D13F5895FEA2727F13474387AD71DA2D8ACDD0DB9FAD35FEA9C04521A4BA94998071C8EBAD349438F99BAA1ACC6E7486D2EA273AA71809160160193747E8EDBAB94AB1C20AE8EC21A5284891842A941A48A42C494EEB9429A75216DAF492612D349086D16252237D6E49DF004B75D7282D3C84B8DAAF498DD1BA222B8B8AA6AFD44C3AB65A4B6A78CDD2359FF0C2E894F66B299967291585A01B35C37E8BF43D1AC71614E2C22AA44A10D8B9B4848F08AEE511158DF5669FD2447F0F476DA3D6D7B6F8DF5B9277C012DD75CA14DB890A42C4949EC84B4CA036DA74503B6D845254D24BED8921DD607F87A7F8D69B73DA00C49B6D0D8C1225FF003CBFFFC4002D1001000102030703050101010100000000011100213141511061718191A1F02050B130C1D1E1F140607080FFDA0008010100013F21FF00E3A051062AD5D893F2C293C4723F35E189CD5897241F06CAC1B990FC95D95DFC2B33B80ECCD418B1918EE49471AB0493DEF419D39F029D31DCEE54970729C0E07D2E3A8950F07C3E8C2A1FCCCCCE27BC6F8072786B4C9CF36C10E585C6A394F9BA158DE6967EF5F225FB95D9F095FC3AEE3C5AC1579E8A9F5DD307E7BD5F38F61E8D323DC421D85F00145B461070E4CA840208E09EE8196E529693A79F1EC04EB40BAD78C0CBB956F42B33C5FA5A0E69CB83449EE6F2A687324EC2D227ED5009E73ECFB91F924D1997FBF77ECB1A1C4A31556FCFC7D6C22F8582ACD651C1FC3B37B6460FEEBE34DF73EE0A05002EB52011ECD5AB6E47E958FDBFC16D38A568ECB36E3B26ACFF00406FA3A0790CCF6F8B38DCBB6C6A01E99F9AF9C74FDD0A84512E2519000F36FF00F007C3C369562CDDFDD6CCC417397E4F6E575C5B59614F417299AD0F3220ABC7B8F7CAF8D37DE57CE3A7EE85422897128C80079B7FF8071D1D0E4942CC343F9A1508C25C68D2727F973F6D8B5D6DEF1E9B2247C266EDF8D37DE57CE3A7EE85422897128C80079B7FD101814461D2BF8BF857F17F0A01814461D3D1105F33F5D924A3A8E6F6C0D6D06FC8EB48CA5256F6B19B8A743368A68406E3635C05320D76472A052C7068D7CE3A7EE8542289712B06F9E3D69338B771EB8C6318C60A30C6AED828C71A9B2394A4C036201092C4A7CC095BD86C9A729C0B3ED70FBF13FB3B20258731BBB7C8DEA8898DC75140863DC5F9A348A448773C6BE71D3F742A1144B8956C7E326FA4472B863E9E2785CDB310BAE53736622E87DBECF6BD2DF35CF646E2CFDA76DBE46F5124112690DBF1A6FBCAF9C74FDD0A84512E255B1F8C9BE9C265B8C4E04B5C538353C886AFB314A34CC13D789E1736EADAF8971F1B37067F03BFB5F009F09B53138A839D1E0C4E46DF237B67F5ABFA75FD9AB1C55928F9C74FDD0A84512E2519000F36FA56EBCE605362A7C99D12645357D732B1702F9235F562785CF47F3C96A03C4DE4CFB5282E84D2CAAE2E35CFE7933E8F237BD23172C98346B0A49CE3371AF9C74FDD0A84512E255B1F8C9BE911CAE18A40CBC239DF1346F2DAFBB33D589E173D10EDCE80ECDF5FEA7B4F84D3619E77A0FA3C8DEF4B8F8B073AC0F5AE982AC71564A3E71D3F742A1144B8956C7E326FA4472B86296FA7CC72ADCCCF27D389E173D1E5746CF2BA3DA4C0D4BB6C719383AFA3C8DEF48AD821C9A509E09A18B964C1AB1EB04A2F5792142A1144B8956E7672D99BE8072B568A8A12B061EBE9C4F0B9E873B91EDD8209C4F81ED5BD2BA2B7D1DEBE8F237BD4D48EAE2CF5A922CFAB928511144C1AB00F0129D800052211B80A08211F93C696DF9BE49D7D389E173D1C42FC1F6D9B92FA0F6ADEAA3E5BF66F86399B7C8DEF558E4DA3A503229B8F8532EE8C6FBA83208E174D3550C049D1D66BB0000A442370156E80E67DCA7E16E40F462785CDA38B07229B172AE75B95CF09BFB5E8F44F1FEF65C8DDF23736F91BDEB4F1AF132A82D6D6EE17ED5627E7A9CDD9043AB5A90DDF0EA576000148846E02ADD01CCFB94FC2DC81B713C2E6D854FDDB1EDB307DCF3367CFB5C784F4CC1D90AD03E4EDB52C6E88EF1FDFD3144451306AC03C04A76000148846E02ADD01CCFB94FC2DC81B02BC5A43CCDB2C2CCF934D92C193E8FCCFB59252303735A2143A99348848491A00B1107418EC816C4351DCFD48C6318C6318C6202205306A8E687166D675AEC00029108DC051333730ACCCDFB2286371315E2ECC1B84C6AE453452C4DED614DB99586BAE47B642EBF4793B2E2C595E83FE0EFA643A95D800052211B80A3239827C63B61AFABF5FD764815BAFCDEDA1B42E09ABF085F5CC1D990EAF7949FE0EFA643A95D800052211B80A3239827C63433F6B95B188998E866D09B0707B71E1F1FC19D22051094939B21578F898FF00077D321D4AEC00029108DC05241C4958D8ACBF3E477F708EDAF032EBC76245B90A1088F1CBFE00CF12CE2B2965B61C7B17F97DBDCB8B30F71BEB0B342888A260D5F461071E4CE8DE042E7D479A4605166755F652275F25D76649714CF7FBA37910FCBF9A6192076765E078950CB7C6E8C68EE655FA7D0DE6C9454A23C8336A48070072D987944AD48AF165F768E03CC38353336865E59F2AC2CD931362020304AB49E0096F41EE07F2AF8141FC5793F95667F107E691DF6FC2969E087CB1A58A58A4BB6149D12EE14B462E35F88FBCE05729D5521E140E158236E7CB0FA1D28C5BAD42B9FBF9150890789972F7EB9BDB90F52BC1179AB22B8C3F8ABD91A428CC1C20AC2DE668AC1CA60A4BAB3FF7A0140315ADC409AF6FF862D984231732DBCC559ABC2376F129D42C44A61044A33B54181D3761D625A5C517C51EB08D6A2AE7E28A52636337230E7421BF610DDA71DD4251113134443CB6EA36A21F20A0658A996658E552733E45B1966D82503983084DE13BA912E38BE3D635AB24BE1249AC094CD000BC12D0F8FEB6BADB42A2E5127328FB3AE70245A0DEC1768468A11C5CD5C6994FD0031DE828EBDDA49BE8E950FF006668625DD2880DF4587C1D6A301E71D35246B2B45243880FB5CBD8AB8BACC671A665640E0FA8D4E4FEF995D570505056CFD4B519E822C0CCC89B91CEA29C0D39D182D96056B2C39450E4F59C826763F7A88DCBB211610BC8577CD784EDFBB07CB5A5DBEA018BC5E8AF0883C610C6CE75F162010265180690C1A744E9128D030C31E1437BF832CE6A77773212FBE0CD134C48431BEE43BD163707662B40A4B422E25DFC6A2234188CD4BA9DF603810406C8F5A91B30F89C279520E89F96FB8BB3BE8AA16508D058A3A41586D040E21F6BEFAC56EC1D62AF7E11C28A58EFA94D037AFCA6950977E8265C6ED8525461767CA5DFD28772BE5746C2904C414F24E72A298B9E5DC864DB0D2760F96BBD5561C96328C67319E173A6F4DA6B80BBDA8D7C40004DEB1C5DF0301B4B64543F54008E6C31A40A12DDB259BACD49B408198B78DF529145C18ACB74AEF5B68BEEDDF3ED65986C527195411938457406C8E83103C1D2D52C51DC6D3AA9A0AB9F82766632C74CB2F36A3F48CAC33A32619A20D96DF2CEC32AD457CFC515A8EA1D008EC55B0698673A3B219305285591DD222B09DE792880A9288DD400571015AA65EAAC9FBDF3F5718E950288354CC8139DD6BB6BC22296E26253F2A1718EC2498E939A285591DD22290E39D82B2A9035E4094BBB530EF6D458EAF7FCB1F0FBE953CD7247B7FEE5FFDA000C03010002000300000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004120024800000000000000000000000000000000000000000000900000000900000000000000000000000000000000000000000800024904800800000000000000000000000000000000000000020004000000020000000000000000000000000000000000000000804800000000024000000000000000000000000000000000000004000000000000004100000000000000000000000000000000000104020000000000024000000000000000000000000000000000004920020000000000004100000000000000000000000000000000020000020000004020000000000000000000000000000000000000824020000924900020120800000000000000000000000000000000100820004000000000004000000000000000000000000000000020804100000000000000000000000000000000000000000000000004020824004820000004020000000000000000000000000000004800100020004900000004100000000000000000000000000000020800800124004800000000000000000000000000000000000000100004000024800000000000000000000000000000000000000000820020000804104000000020000000000000000000000000000000820100000120120000004000000000000000000000000000000000100800004104120000004000000000000000000000000000000000800000000004120000020000000000000000000000000000000024820000000000100820900000000000000000000000000000000004000000000000100000000000000000000000000000000000000804000000000000100920000000000000000000000000000000000920000000000000104000000000000000000000000000000000000024000000000004000000000000000000000000000000000000000100000000000800000000000000000000000000000000000000000104100000120120000000000000000000000000000000000000000020920924004000000000000000000000000000000000000000000100000004800000000000000000000000000000000000000000000020120020000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000024000000000000000000000000000000000000000000000000000020124900124020804800800000000000000000000000000000000904920100904900104104000000000000000000000000000000004000804024020020120000000000000000000000000000000000020804124004924900804120000000000000000000000000000000000000000000000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFC400141101000000000000000000000000000000B0FFDA0008010301013F10434FFFC400141101000000000000000000000000000000B0FFDA0008010201013F10434FFFC4002D100100010302040505010101010100000001110021314151617181911050A1B1F130C1D1E1F02040607080FFDA0008010100013F10FF00F1D5D29A901CD6A68187F263D75290434FB0292573C46C775706EF3F892BE44FC5292AD6CF7CA82B3E849A4506FE8F41EEAE00515FD196B0E0E44E49E77BFDB3BF0647A546460027D81D7B56DCE8FB058E87D2DC61284F330F5A8E4D78FAD9BA4558965B639E5CF3750156032D2F0559EEBEEFA73AC98E967A060381E0D0CE0CA3C028ED4F163D67BC54226F63B377AD47CA1AFDCA96C176C5722BE2952973CEB5CCA9CB8EA1F7292A370A0FA3144D91FF00873D16B3151E0E63E198E6686941A2CF0FF85CB72A380F2E911D47CD01ED68653653A1C78DC3C3BF83EAA8391B01522E97B0BEE1EA79543EB1004F39BBF4B87366FC85CE944B032A87B27AF7A4C170041E23E1282571BCB2BA72C3EB46FF006C323B1A26DE6520660FECB5A897FBF2BD3DEAE1C4D29C5D5D8A3F6040B981B381D67EB587034BCB7538350192407A4FB1DA7C2624D340EE6DB1A35E2EAB50D13CC0C83ABB00656B86909D2FC1C3C44A6B31C43F7EFF00F00CE087912AFD0E1EEAFF0023E125130E17B4F5A3506BF0984F2F81840A699EAE5E9C7C024D13D26716957D08502C76761A94E19C5A11308D1A8584B00FE73FF81391B14ACD651457A7DC3D7C18EE83AEB3C9A38F3F2E81B04DE59F77853A87E72E1697287C5B50D7CDA99FC3851AF1755A268957D08502C76761A94E19C5A11308D1A8584B00FE73FF0082D3638C7DD1583F3184C83825E9C33C1D91309465BB29F62FE5AD38D926329D16EFE1AF1A6E86DD76DDF7F135E2EAB44D12AFA10A058ECEC3529C338B422611A350B09601FCE7F44A9E12C86C5FC5D3A353C25D4DCB7F815A162397FCEFCA7C316E25C1F996EBE591E08FBCC3A9029E93CDD5256ADE86EF1D025A13BB39841E00865B88B69044CB8AF8A519BEFA1A703A6F57D08502C76761A94E19C5A11308D408632C443586D1DB5A9C83A03F6372BE295F14AF8A57C52BE295F14A6393144191B78B1C08A24C85ABE2957E042C2A0D99849F03B0657711C8D39C6ED6B79F6A1464B261A9C53FC34CA4F95B40CA976C79876F0C6C07EBBD08EFFE38CFE9CB1004BCDAB07D0E89E0C29DDB790E388D9BD5F42140B1D9D86A5386716844C235A637405059343EB57E8740F91B9F59A86464733B2CF7F054C17959484D919B4A4BC27642B8B9FB1FE386EE18400655F135E2EAB44D12AFA10A058ECEC3529C338B422611AD31BA0282C9A1F5A4A5A169BD60ED5636D8B7346DCCA6EC755DA9A5840946C8FD26B6F64A7FBAFE0962C371508F63CAEEBC8EEB0F456137F3D4145440C70107F9E010010B00ABE6940B20A619D3A31F0D6E11D07AD5F42140B1D9D86A5386716844C2346A1E12C03F9CE9E8DA8F5CEFBD596A5777D0076ABE0161227083B141A4D959381F49AE6123B9314D2EB01B97D94220888DC4F2995EE343952329495C5AD4A161C057B7D1E1108A2432351D94231C7782F357D08502C76761A94E19C5A11308D698DD014164D0FAD5FA1D03E46E54B4C896461B1FB518380B9413D73D63E93503C89FE8BBF85DF9BAF25F29FEAEFF00086E21772FB7D1E3D62D85145906E027B98A7463E1ADC23A0F5ABE8428163B3B0D4A70CE2D089846B4C6E80A0B2687D6AFD0E81F2372987BE96F2B6EE7754758E5C60FA2D404204ABE576A516C98F35E12C9B8CB913EFF00478F45A001ABA9B3B3687DB4884512191A74216196621D07AD25CC915BEC26A5386716844C234D8B9214326875DE9307460505DAAE2737DC193F45AC7B89757EFE0C22014F2A992CB1D51579E075C033F4B894C6E17B703C97EB404294CD7CBECF1A44CF27644C234E81336D661341EBDCA4A77081FA09A949FC04211308D09882B30430310D4EA702B1330F40E3B9A7D16B16B2027C17C5541E5560A001C3C0000CF50049DFE8F0EE9143BCCC0386BC3A52B024A0B2D56A3A94FEC38B30E3A9CA79D484E8C4C3A45A68A46870C28D877887D2929DC207E826A527F010844C234E800938161D03A9AF2909C0294FAF3EE69FEDAA79081C04B57E259E2A5AB55274A9ECF2B850F5957F41E037C4635CF7AA74FA5C464113255C4DDCBACD02356185CA936D3BBB44D1609BF2D85F4A47EEA494ED363D6F4A4A77081FA09A949FC04211308D3A0024E058740EA6BCA42700A53EBCFB9A7FA6A0041CF57E9BE0A2A52FE89EA7A795DB888467F559E9E19740ED0BAEF3D5E21429DA552A7A3E9A26793B22611A74099B6B309A0F5EE5253B840FD04D4A4FE0210898469D0012702C3A07535E521380529F5E7DCD3C0E29DAA261F1BCA7666FA43D7C2DADEAA0F579585F3AFD4212A796511AB7EB17A4F840F225C6A1D0857821F738785EA6DD9370172BE6DF8AF9B7E2BE6DF8AF9B7E2BE6DF8AF9B7E2BE6DF8AF9B7E2BE6DF8AF9B7E2BE6DF8A5CFF26844C234713804501830C2929DC207E826A527F010844C235BE8A877B31BCD79487CDBF142DD92EABE25FC174BF1D20736D5CD69CC4B40C4F34944BCA8718E5D08F2C69B04237BE9AC753C0AFD239B61E5E8FEBFE0D0BE1E89344A4A77081FA09A949FC04211308D0790DB01A9EE3A9C3C0E729818C71EDE73E1AFA93EEC3C8B757CB490BA8D421A968FE511C1E3E045AC22E3FC3DF7FF008342F87A24D12929DC207E826A527F010844C2341E436C06A7B8EA70891956E71ABEDC7952AAAAAB75686CC05E0B2700A8C029EAEEBC56EF97320095D69DD3B7BA9079AC0896468E0CB3C25406216B5FB2FA7FC1A17C3D12689494EE103F4135293F808422611A7F75394E940A0156C05623120E731F77E9E60F370C9EE1A783D79E690E56A74C69DB30EB2F6FF8276BC546A1D8F5C627C55C2D9A66C5FCD76F329654E7BE0FD46BCF28A4112C8D226793B22611A1218B349381EA2FCEB2DDCC07B7D437A92A00E2B40012C16C733DDEDAD3EA99390EAAF834B831DAC3B70EFE69B93783A1C3F2ACF69358DC709C4F09D09E273DB35A6B966E62ECE935155E5011CF23AFD0DBA90A5C8D7A56C1FE71E31F82A1D9B21D91B75CF83A1481CAD3F14C65A7F17C1A6FE6CE79783EF90A6A31BC3D6FE1B52290510991F0B8CB1509D4A8510D13FA38D45F127DEEAF8E31F7D3C1E0E783FDA0A4E709A504534D37A1F75660E409CD7C51615F0AEE7563AD46403F9A3916F391D65CB58FA33D669FD0276085DE949B06D72E833EAFA0E59B12E3CF03BD3BF8463B59DDAF8A6255B740F3E5D49C82FCE06A42E7BCC76550DBF83DA29F91D779FB515B0F07BC351D62D239ECAC03A40E7754000000580FFDE073997401C56BE2538C9FFC30D55B328981944992CC1061417A074D0A731C139D209BB8B8F4B29614A5E69025F217C628777A911590CC370A9788550818207429B37C8D36BB7A28021950E75FC9A457395FB902BC178AE81B19304EAB543E02FD0790DCD5ECD11EF3E00959D69712ED56C18D03596A6B160F8C528B10269844951692B65DC1A039B430CD6245DFF7AA27AC0871690A9BA4338C65342E052B3300DE3164FD0AC3C5742C0E6352A700506104138B4EF46C2419D444E1BD2A446282535B00173462630A98E61D55B9A2BAEC46E7108AB021422DC2363198F2B2584A04A6411D5929241BD3CC6FD43730EC518EEE02A404972E269C6D41C7D05940608BC31011143C08693B0AC1B910C9832C804E61749A6B89488F29E554B91446A096E85C77510E786EEE0882873512D6E7105477FF0013586258C0320FC42C9CEB2A1A01C02334D57BD1DB604395420080CC4F1AD4569FB303AA6D305AAECD52AC364376356CD0D26401CCD8B5568D9A4C015F24819420788A1D5F97048099180365524D5CCDB95103293C4A43F1220CC497BC0B82D4574E2DFBE465D3060B52229F9AD20A812D110A13160280CC5E16E8BEC94220769D12B22193DEB36DB6ED2641C48A68C41443E47C4E160B0969F2B2E250BF37A2267538544C89B463520D181BD5C434BB452598581B92C451FBD1BB66CA24924B745D539EA24FA01C27781C6880000100FF004A9F1A87F5C006509484C868D2E0F044992A64327F93ECEC0B8E777F04E37037345112344A34933D471A043C6C13417B937A56A796E1B2300A18B2230D1C9A847561294C10471A3B439489A3564701A7524B46AC21730274D6D515E4A86C872C4278F80BFE5EEF2D9A44F7FD6DEE54A3C5692ACCC48EFED8A0000002C0548A2F223B090709A1EC24BCCDC0E543C42AA40C109A3E0BE42132937771A0C0C86B010B2376835861804076F00C3C42590A589896A063154642495D4A3EA700C61A6762E9413F8C1E209EA576F86C114B756A98C97A76628FCAD99230F04D12E558BF869614034428E8AC5449295DFB9527E8C1E898B108D9DAA2D42D4888058C844045E6C9EAB739867D0A977EB9D395117A54B285C777250E134B756A98C97A7662B02249D215CEB44AAECEC1CD1A879A41E7A7C9E7F17A12C4EF539524AD8F221FFDCBFFD9";
                    int NumberChars = x.Length;
                    byte[] bytes = new byte[NumberChars / 2];
                    for (int i = 0; i < NumberChars; i += 2)
                        bytes[i / 2] = Convert.ToByte(x.Substring(i, 2), 16);
                    basesMilitares.logo = bytes;
                }
              
                db.BasesMilitares.Add(basesMilitares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!new HomeController().Master(this))
            {
                int idbasemilitar = new HomeController().Base(this);
                var consultar = from usuario in db.BasesMilitares
                                join c in db.BasesMilitares on usuario.id_BasesMilitares equals c.id_BasesMilitares
                                where c.id_BasesMilitares == idbasemilitar
                                select usuario;
                return RedirectToAction("SemPermissao", "Home");
            }

            return View(basesMilitares);
        }

        //    else
        //        return View(db.BasesMilitares.ToList());
        //}


        // GET: BasesMilitares/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasesMilitares basesMilitares = db.BasesMilitares.Find(id);
            if (basesMilitares == null)
            {
                return HttpNotFound();
            }
              if (!new HomeController().Master(this))
            {
            return View(basesMilitares);
        }
              else
                  return View(db.BasesMilitares.ToList());
        }
        // POST: BasesMilitares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id_BasesMilitares,nome,descricao,TipoBase,Tipologradouro,Rua,endereco,complemento,numero,bairro,cidade,uf,email,nome_contato,pais,logo,latlon,Cep,Telefone,NomeFantasia")] BasesMilitares basesMilitares, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    byte[] PhotoArray = new Byte[file.ContentLength];
                    System.IO.Stream PhotoStream = file.InputStream;
                    PhotoStream.Read(PhotoArray, 0, file.ContentLength);

                    basesMilitares.logo = PhotoArray;
                }
                else
                {
                    basesMilitares.logo = new BasesMilitaresContext().BasesMilitares.Find(basesMilitares.id_BasesMilitares).logo;
                }
                db.Entry(basesMilitares).State = EntityState.Modified;
                db.SaveChanges();
                if (!new HomeController().Master(this))
                {
                    return RedirectToAction("Index");
                }
                if (!new HomeController().Master(this))
                {
                    return View(basesMilitares);
                }
                else
                    return View(db.BasesMilitares.ToList());
            }
            else
                return RedirectToAction("SemPermissao", "Home");
        }
        // GET: BasesMilitares/Delete/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasesMilitares basesMilitares = db.BasesMilitares.Find(id);
            if (basesMilitares == null)
            {
                return HttpNotFound();
            }
              if (!new HomeController().Master(this))
            {
            return View(basesMilitares);
        }
              else
                  return View(db.BasesMilitares.ToList());
        }
        // POST: BasesMilitares/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmed(int id)
        {
            if (!new HomeController().Master(this)){
            BasesMilitares basesMilitares = db.BasesMilitares.Find(id);
            db.BasesMilitares.Remove(basesMilitares);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            else
                return View(db.BasesMilitares.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //pdf bases militares

        public ActionResult GerarRelatorioBases(int? pagina, Boolean? gerarPDF)
        {
            var GerarRelatorioBases = db.BasesMilitares.OrderBy(n => n.id_BasesMilitares).ToList<BasesMilitares>();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(GerarRelatorioBases.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "GerarRelatorioBases",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = GerarRelatorioBases.ToPagedList(paginaNumero, GerarRelatorioBases.Count)
                };
                return pdf;
            }
        }

        //gerar pdf
        /*
        * Retorna a view simples em HTML, usada como modelo para gerar o PDF
        */
        public ActionResult ModeloHTML()
        {
            return View("GerarRelatorioBasess");
        }

        /*
         * Retorna um PDF diretamente no browser com as configurações padrões
         * ViewName é setado somente para utilizar o próprio Modelo anterior
         * Caso não queira setar o ViewName, você deve gerar a view com o mesmo nome da action
         */
        public ActionResult PDFPadrao()
        {
            var pdf = new ViewAsPdf
            {
                ViewName = "GerarRelatorioBases"
            };
            return pdf;
        }

        /*
         * Configura algumas propriedades do PDF, inclusive o nome do arquivo gerado,
         * Porem agora ele baixa o pdf ao invés de mostrar no browser
         */
        public ActionResult PDFConfigurado()
        {
            var pdf = new ViewAsPdf
            {
                ViewName = "GerarRelatorioBases",
                FileName = "GerarRelatorioBases.pdf",
                PageSize = Size.A4,
                IsGrayScale = true,
                PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 },
            };
            return pdf;
        }

      



      

        

    }
}
