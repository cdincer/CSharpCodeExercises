using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Leetcode.ArrayRelated
{
    public class ArrayLeetCode1
    {
        #region  Minimum Difference Between Largest and Smallest Value in Three Moves
        /*
        Extra Test Cases:
        [1,3] 5 / 61 testcases passed and 43 / 61 testcases passed (Check submission tab for more details)
        [6,6,0,1,1,4,6]
        [483816,581660,150599,99980,280917,82031,844335,653573,164609,418141,663011,62614,524550,970526,883748,7715,120527,192499,797001,166728,669994,457603,440624,157239,678732,839826,301509,221419,967440,902123,708926,685047,706736,853335,376884,981898,99510,937726,476934,92553,541045,659137,806479,581051,953499,983885,353111,214417,511032,917306,26281,970799,714622,748134,801883,640576,965371,711909,272145,365174,202868,384674,804134,517889,81504,170578,52640,803925,139923,63206,443452,699309,269512,570233,129763,246921,545380,197243,583471,282363,511853,854431,769226,75703,167480,621141,48040,221707,877292,610486,187933,401970,685238,197163,7679,630841,127330,375224,981927,580903,353257,478921,419129,56143,654415,351517,453455,723033,602754,432579,394457,614737,531420,90540,389220,949922,896497,176884,698826,748477,142118,171130,864006,673437,542250,692136,398080,954734,608123,130513,25716,620902,9622,652606,197831,354583,532261,118336,641966,645816,341639,488580,775690,447695,43684,194753,635758,437066,930747,300478,77699,838564,175307,608794,56734,302066,452191,174763,665199,288415,760385,381263,494160,879824,301520,241932,486909,987798,851168,782169,883485,811896,204690,652666,248732,355220,605505,116022,733258,377843,117104,579230,349731,453468,767639,667173,985503,219699,58249,345836,708289,842219,784292,990119,221904,77942,267565,230267,600631,546226,287468,864457,667110,318024,441342,796726,825548,461252,123240,491784,241412,467610,930551,321804,4072,618657,283670,181619,356174,285806,997658,286171,243661,205039,926569,674159,647664,471021,762140,743163,523432,350187,329996,800914,845295,719765,134303,530168,573416,70206,704403,643251,895132,207656,516446,151673,766719,797091,955873,359469,925640,942779,390049,336636,830910,34995,516960,305524,733025,350428,297445,458452,561231,206491,335090,433063,603437,373006,694896,404006,375216,82344,3910,908447,802380,677425,297328,459274,396524,238744,986403,995169,765977,855395,991330,422985,818016,177774,3940,742952,459980,301188,838637,655728,629309,57288,561828,402667,509682,844159,415407,940658,871384,825648,499417,454307,437746,973247,598446,814866,915962,634148,569061,921621,163869,745295,432586,993743,781709,666674,378612,942091,556357,885845,484421,475779,841287,478780,96713,513231,732624,486091,172662,715018,255162,85106,575744,249888,905482,373630,884184,730723,204680,252728,326508,530055,514175,19171,794540,904624,250686,495773,735639,345455,558927,963284,742115,189970,222199,924191,697012,339984,728728,398613,691951,176968,606737,202423,43037,99642,850834,845687,766581,401300,377540,188847,432272,316807,514238,61872,529052,147347,319476,951996,205821,546337,644676,53134,100559,812997,440920,190919,284201,932474,311767,14578,808956,336935,848592,596811,555708,529289,534623,228900,490471,808298,894423,39595,91694,960686,276861,60084,377110,792159,71521,918347,459902,939910,167133,551192,413207,997111,534369,463640,358152,6169,129945,94032,968900,88376,54816,890705,667274,135854,549478,425710,919295,292839,138348,253193,611261,574690,308224,59794,418396,917402,852164,99702,294405,145743,804760,726929,437741,31473,695593,759777,399909,916182,379778,318525,136636,703805,683220,834760,299746,329269,879631,908069,885103,452156,711665,265683,420506,982759,388841,820800,947656,805606,64682,856400,721608,224448,765411,417722,439135,959292,103754,692038,21256,764340,989865,113019,399474,162775,590716,570482,517369,807980,811542,292192,52631,685808,249909,379272,491501,238385,921247,313944,259932,675291,334324,572214,897449,641277,423514,18858,693562,174541,545105,623875,859853,379975,70464,438705,709705,145334,182151,929304,464887,690139,206492,347863,155035,506958,778280,339264,603321,516569,311004,26917,80063,628534,511510,553867,547898,723909,399097,336137,730505,68254,876861,325196,199577,368600,872636,691949,836754,136706,748567,351773,917723,449630,848616,27536,342928,575098,601458,702471,536789,699513,76084,825026,370512,471073,540641,196378,144795,497356,155951,966063,372846,707518,721152,436717,229391,444927,452191,283044,18375,234490,908427,444419,894472,280707,765465,341037,954331,83603,553154,282206,83091,920469,31928,919004,890046,449603,642550,194665,663818,26380,606557,539332,624483,260039,591605,172148,707014,389942,287517,921609,151645,594711,553140,383096,445419,181583,444390,440955,256946,446896,385779,209376,959957,100895,697405,464245,713719,943968,458810,122041,205351,734885,30635,13113,134143,152975,282592,158903,48831,438571,927801,697883,313637,634905,498504,44810,338301,7785,538678,183948,841294,748527,623304,400907,225147,222760,595302,620121,182532,100226,433672,963633,561787,586222,117517,590221,846223,144518,383834,602210,789680,339936,152937,175756,505090,549502,363751,15587,269200,270500,439573,704586,106922,388171,760790,442660,432708,961172,414672,846771,21647,702620,769070,447518,872906,590313,869701,395735,300284,530656,883800,619063,199914,234462,385326,33136,546160,105459,161289,759597,565193,969609,972766,790541,432020,999554,476148,993299,905662,266506,919538,477292,773842,266365,583118,801226,501505,479950,40077]
        https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/
        */
        public int MinDifference(int[] nums)
        {
            int arrayMin = nums.Min();
            int arrayMax = nums.Max();

            if(nums.Length == 2)
            return nums[0] > nums[1] ? nums[1] - nums[0] : nums[0] - nums[1];

            int[] wiparr = new int[nums.Length];
            Array.Copy(nums,wiparr,nums.Length);
            Array.Sort(wiparr);
            int ti = wiparr.Length - 1;
            for (int i = 3; i > 0; i--)
            {
                wiparr[ti] = arrayMin;
                ti--;
            }
            int decreaseR = wiparr.Max() - wiparr.Min();
            Array.Clear(wiparr);
            Array.Copy(nums, wiparr, wiparr.Length);
            Array.Sort(wiparr);
            for (int i = 0; i < 3; i++)
            {
                wiparr[i] = arrayMax;
            }
            int increaseR = wiparr.Max() - wiparr.Min();
            return Math.Min(decreaseR, increaseR);
        }
        #endregion


    }
}