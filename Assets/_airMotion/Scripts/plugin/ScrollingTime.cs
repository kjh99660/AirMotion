/// <summary>
/// Brought you by Mrs. YakaYocha
/// https://www.youtube.com/channel/UCHp8LZ_0-iCvl-5pjHATsgw
/// 
/// Please donate: https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RJ8D9FRFQF9VS
/// </summary>

namespace UnityEngine.UI.Extensions.Examples
{
    public class ScrollingTime : MonoBehaviour
    {
        public RectTransform minutesScrollingPanel;
        public RectTransform hoursScrollingPanel;

        public ScrollRect minutesScrollRect;
        public ScrollRect hoursScrollRect;

        public GameObject hoursButtonPrefab;
        public GameObject minutesButtonPrefab;

        private GameObject[] minutesButtons;
        private GameObject[] hoursButtons;

        public RectTransform minutesCenter;
        public RectTransform hoursCenter;

        UIVerticalScroller hoursVerticalScroller;
        UIVerticalScroller minutesVerticalScroller;

        private int monthsSet;
        private int yearsSet;

        public Text[] time;
        public void ShowTime()
        {
            foreach (Text _ in time)
            {
                _.color = new Color(_.color.r, _.color.g, _.color.b, 1f);
                _.text = hoursVerticalScroller.result + " " + minutesVerticalScroller.result;
            }
        }
        private void InitializeHour()
        {
            int[] Hour = new int[24];

            hoursButtons = new GameObject[Hour.Length];
            for (int i = 0; i < Hour.Length; i++)
            {
                Hour[i] = i + 1;
                string month = "" + Hour[i];
                if (i < 9) month = "0" + month;

                GameObject clone = Instantiate(hoursButtonPrefab, hoursScrollingPanel);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.GetComponentInChildren<Text>().text = month + "½Ã";
                clone.name = "Hour_" + Hour[i];
                clone.AddComponent<CanvasGroup>();
                hoursButtons[i] = clone;
            }

        }

        //Initialize minute
        private void InitializeMinute()
        {
            int[] minute = new int[60];

            minutesButtons = new GameObject[minute.Length];
            for (int i = 0; i < minute.Length; i++)
            {
                minute[i] = i + 1;
                string month = "" + minute[i];
                if (i < 9) month = "0" + month;

                GameObject clone = Instantiate(minutesButtonPrefab, minutesScrollingPanel);
                clone.transform.localScale = new Vector3(1, 1, 1);
                clone.GetComponentInChildren<Text>().text = month + "ºÐ";
                clone.name = "Month_" + minute[i];
                clone.AddComponent<CanvasGroup>();
                minutesButtons[i] = clone;
            }
        }


        // Use this for initialization
        public void Awake()
        {
            InitializeHour();
            InitializeMinute();

            //Yes Unity complains about this but it doesn't matter in this case.
            hoursVerticalScroller = new UIVerticalScroller(hoursCenter, hoursCenter, hoursScrollRect, hoursButtons);
            minutesVerticalScroller = new UIVerticalScroller(minutesCenter, minutesCenter, minutesScrollRect, minutesButtons);

            hoursVerticalScroller.Start();
            minutesVerticalScroller.Start();
        }

        public void SetDate()
        {
            minutesVerticalScroller.SnapToElement(monthsSet);
            hoursVerticalScroller.SnapToElement(yearsSet);
        }

        void Update()
        {
            minutesVerticalScroller.Update();
            hoursVerticalScroller.Update();
        }

        public void MonthsScrollUp()
        {
            minutesVerticalScroller.ScrollUp();
        }

        public void MonthsScrollDown()
        {
            minutesVerticalScroller.ScrollDown();
        }

        public void YearsScrollUp()
        {
            hoursVerticalScroller.ScrollUp();
        }

        public void YearsScrollDown()
        {
            hoursVerticalScroller.ScrollDown();
        }
    }
}