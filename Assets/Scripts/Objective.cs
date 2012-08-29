using System;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string Time;
    public bool Complete { get; private set; }

    
    private DateTime targetTime;
    private DateTime timeCompleted;

    public bool Active;
    public Objective Next;
    public string File;
    public int TextHeight;
    public string Title;
	public float Penalty;
	private Player player;
    public bool TimeExempt;

    void Start()
    {
        if (Active)
            Activate();
        else
            Deactivate();
    }
	
	void Awake()
	{
		player = (Player)FindObjectOfType(typeof(Player));
        print(string.Format("Objective {0} loaded timeexempt {1}: ", this.Title, TimeExempt));
	}

    public TimeSpan GetTimeRemaining()
    {
        return (Complete)
                   ? targetTime.Subtract(timeCompleted)
                   : targetTime.Subtract(DateTime.Now);
    }

    void Update()
    {
        print("Total milliseconds remaining:" + GetTimeRemaining().TotalMilliseconds);
        print(string.Format("Objective {0} loaded timeexempt {1}: ", this.Title, TimeExempt));

        if (Active && !TimeExempt && GetTimeRemaining().TotalMilliseconds <= 0)
        {
            print("End game");
            Application.LoadLevel(0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            timeCompleted = DateTime.Now;
            Complete = true;
        }
    }

    public void Activate()
    {
        print(string.Format("{0} was activated.", this.name));
        this.Active = true;
        this.Complete = false;

        TimeSpan timespan;

        if (!TimeSpan.TryParse(Time, out timespan))
        {
            print("You entered the time incorrectly dumbass. Eg: 00:05:00");
            return;
        }

        targetTime = DateTime.Now.Add(timespan);
        gameObject.renderer.enabled = true;
        ((Light)gameObject.GetComponentInChildren(typeof(Light))).enabled = true;
    }

    public void Deactivate()
    {
        print(string.Format("{0} was deactived.", this.name));

        this.Active = false;
        gameObject.renderer.enabled = false;
        ((Light)gameObject.GetComponentInChildren(typeof (Light))).enabled = false;
    }

    public void SetNext()
    {
        this.Deactivate();

        if (Next != null)
        {
         	player.Karma -= Penalty;   
            Next.Activate();
        }
        else
        {
            // Game Completed.
        }
    }
}
