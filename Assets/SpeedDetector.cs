using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDetector : MonoBehaviour
{
	public Text text;
	private const long TICKS_PER_SECOND = System.TimeSpan.TicksPerMillisecond * 1000;
	private const int THRESHOLD = 5000000; // == 500 ms, allowed time difference between genuine and vulnerable ticks

	[Tooltip("Time (in seconds) between detector checks.")]
	public float interval = 1f;
	
	
//	private byte currentFalsePositives;
	private int currentCooldownShots;
	private long ticksOnStart;
	private long vulnerableTicksOnStart;
	private long prevTicks;
	private long prevIntervalTicks;

	void Update()
	{
		var ticks = System.DateTime.UtcNow.Ticks;
		var ticksSpentSinceLastUpdate = ticks - prevTicks;

		if (ticksSpentSinceLastUpdate < 0 || ticksSpentSinceLastUpdate > TICKS_PER_SECOND)
		{
			ResetStartTicks();
			return;
		}

		prevTicks = ticks;
		var intervalTicks = (long) (interval * TICKS_PER_SECOND);

		// return if configured interval is not passed yet
		if (ticks - prevIntervalTicks < intervalTicks) return;

		var ticksFromStart = ticks - ticksOnStart;

		var vulnerableTicks = System.Environment.TickCount * System.TimeSpan.TicksPerMillisecond;
		var ticksCheated = Mathf.Abs((vulnerableTicks - vulnerableTicksOnStart) - (ticksFromStart)) > THRESHOLD;

		if (ticksCheated)
		{
			text.text = ticksCheated + "CHEAT DETECT";
			ResetStartTicks();
		}

		prevIntervalTicks = ticks;
	}

	private void ResetStartTicks()
	{
		ticksOnStart = System.DateTime.UtcNow.Ticks;
		vulnerableTicksOnStart = System.Environment.TickCount * System.TimeSpan.TicksPerMillisecond;
		prevTicks = ticksOnStart;
		prevIntervalTicks = ticksOnStart;
	}
}