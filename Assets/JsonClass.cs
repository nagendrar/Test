using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Details
{
    public string name;
    public string gender;
    public string dob;
}

[Serializable]
public class Match
{
    public string galleryId;
    public double matchscore;
    public Details details;
    public string galleryPhoto;
}

[Serializable]
public class JsonClass
{
    public int status;
    public int responseCode;
    public string responseText;
    public string responseStatus;
    public List<Match> matches;
}
