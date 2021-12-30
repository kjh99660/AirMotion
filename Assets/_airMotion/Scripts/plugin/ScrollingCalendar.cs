/// <summary>
/// Brought you by Mrs. YakaYocha
/// https://www.youtube.com/channel/UCHp8LZ_0-iCvl-5pjHATsgw
/// 
/// Please donate: https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RJ8D9FRFQF9VS
/// </summary>

namespace UnityEngine.UI.Extensions.Examples
{
    public class ScrollingCalendar : MonoBehaviour
    {
        public RectTransform monthsScrollingPanel;
        public RectTransform yearsScrollingPanel;
        public RectTransform daysScrollingPanel;

        public ScrollRect monthsScrollRect;
        public ScrollRect yearsScrollRect;
        public ScrollRect daysScrollRect;

        public GameObject yearsButtonPrefab;
        public GameObject monthsButtonPrefab;
        public GameObject daysButtonPrefab;

        private GameObject[] monthsButtons;
        private GameObject[] yearsButtons;
        private GameObject[] daysButtons;

        public RectTransform monthCenter;
        public RectTransform yearsCenter;
        public RectTransform daysCenter;

        UIVerticalScroller yearsVerticalScroller;
        UIVerticalScroller monthsVerticalScroller;
        UIVerticalScroller daysVerticalScroller;

        private int daysSet;
        private int monthsSet;
        private int yearsSet;

        public Text[] text;

        private void InitializeYears()
        {
            int currentYear = int.Parse(System.DateTime.Now.ToString("yyyy"));

            int[] arrayYears = new int[currentYear + 1 - 1980];

            yearsButtons = new GameObject[arrayYears.Length];

            for (int i = 0; i < arrayYears.Length; i++)
            {
                arrayYears[i] = currentYear - i;

                GameObject clone = Instantiate(yearsButtonPrefab, yearsScrollingPanel);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.GetComponentInChildren<Text>().text = "" + arrayYears[i] + "년";
                clone.name = "Year_" + arrayYears[i];
                clone.AddComponent<CanvasGroup>();
                yearsButtons[i] = clone;

            }

        }

        //Initialize Months
        private void InitializeMonths()
        {
            int[] months = new int[12];

            monthsButtons = new GameObject[months.Length];
            for (int i = 0; i < months.Length; i++)
            {
                months[i] = i + 1;
                string month = "" + months[i];

                GameObject clone = Instantiate(monthsButtonPrefab, monthsScrollingPanel);
                clone.transform.localScale = new Vector3(1, 1, 1);               
                clone.GetComponentInChildren<Text>().text = month+"월";
                clone.name = "Month_" + months[i];
                clone.AddComponent<CanvasGroup>();
                monthsButtons[i] = clone;
            }
        }

        private void InitializeDays()
        {
            int[] days = new int[31];
            daysButtons = new GameObject[days.Length];

            for (var i = 0; i < days.Length; i++)
            {
                days[i] = i + 1;
                GameObject clone = Instantiate(daysButtonPrefab, daysScrollingPanel);
                clone.GetComponentInChildren<Text>().text = "" + days[i]+"일";
                clone.name = "Day_" + days[i];
                clone.AddComponent<CanvasGroup>();
                daysButtons[i] = clone;
            }
        }

        // Use this for initialization
        public void Awake()
        {
            InitializeYears();
            InitializeMonths();
            InitializeDays();

            //Yes Unity complains about this but it doesn't matter in this case.
            monthsVerticalScroller = new UIVerticalScroller(monthCenter, monthCenter, monthsScrollRect, monthsButtons);
            yearsVerticalScroller = new UIVerticalScroller(yearsCenter, yearsCenter, yearsScrollRect, yearsButtons);
            daysVerticalScroller = new UIVerticalScroller(daysCenter, daysCenter, daysScrollRect, daysButtons);

            monthsVerticalScroller.Start();
            yearsVerticalScroller.Start();
            daysVerticalScroller.Start();
        }

        public void ShowDate()
        {
            foreach(Text _ in text)
            {
                _.color = new Color(_.color.r, _.color.g, _.color.b, 1f);
                _.text = yearsVerticalScroller.result.Substring(0, yearsVerticalScroller.result.Length - 1) + "." +
                    monthsVerticalScroller.result.Substring(0, monthsVerticalScroller.result.Length - 1)
                    + "." + daysVerticalScroller.result.Substring(0, monthsVerticalScroller.result.Length - 1);
            }
        }

        public void SetDate()
        {
            daysVerticalScroller.SnapToElement(daysSet);
            monthsVerticalScroller.SnapToElement(monthsSet);
            yearsVerticalScroller.SnapToElement(yearsSet);
        }

        void Update()
        {
            monthsVerticalScroller.Update();
            yearsVerticalScroller.Update();
            daysVerticalScroller.Update();
        }

        public void DaysScrollUp()
        {
            daysVerticalScroller.ScrollUp();
        }

        public void DaysScrollDown()
        {
            daysVerticalScroller.ScrollDown();
        }

        public void MonthsScrollUp()
        {
            monthsVerticalScroller.ScrollUp();
        }

        public void MonthsScrollDown()
        {
            monthsVerticalScroller.ScrollDown();
        }

        public void YearsScrollUp()
        {
            yearsVerticalScroller.ScrollUp();
        }

        public void YearsScrollDown()
        {
            yearsVerticalScroller.ScrollDown();
        }
    }
}