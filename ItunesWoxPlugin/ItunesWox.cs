using iTunesLib;
using System;
using System.Collections.Generic;
using Wox.Plugin;

namespace ItunesWoxPlugin
{
    public class ItunesWox : IPlugin
    {
        private IiTunes _itApp;

        public void Init(PluginInitContext context)
        {
            _itApp = null;
        }

        public List<Result> Query(Query query)
        {
            try
            {
                if (_itApp == null)
                {
                    return new List<Result>
                    {
                        new Result
                        {
                            Title = "Start Itunes Plugin",
                            SubTitle = "",
                            IcoPath = "Images\\Itunes.png",
                            Action = e => {
                                _itApp = new iTunesApp();
                                return true;
                            }
                        }
                    };
                } else if (query.Search.Contains("exit"))
                {
                    return new List<Result>
                    {
                        new Result
                        {
                            Title = "Quit Itunes",
                            SubTitle = "",
                            IcoPath = "Images\\Itunes.png",
                            Action = e => {
                                _itApp.Quit();
                                _itApp = null;
                                return true;
                            }
                        }
                    };
                }
            }
            catch (Exception)
            {
                // TODO: Something to start the Itunes music player
                throw;
            }



            if (string.IsNullOrWhiteSpace(query.Search))
            {
                return StandardMenu();
            }
            return SearchTrack(query);
        }

        private List<Result> SearchTrack(Query query)
        {
            var result = new List<Result>();
            var songList = _itApp.LibraryPlaylist.Search(query.Search, ITPlaylistSearchField.ITPlaylistSearchFieldAll);

            if (songList != null)
            {
                for (int i = 1; i <= songList.Count && i<=10 ; i++)
                {
                    var track = songList.ItemByPlayOrder[i];
                    result.Add(
                        new Result
                        {
                            Title = songList.ItemByPlayOrder[i].Name,
                            SubTitle = $"{songList.ItemByPlayOrder[i].Album} - {songList.ItemByPlayOrder[i].Artist}",
                            IcoPath = "Images\\Itunes.png",
                            Action = e => {
                                track.Play();
                                return false;
                            }
                        });
                }
            }

            return result;
        }

        private List<Result> StandardMenu()
        {
            List<Result> results = new List<Result>
            {
                new Result()
                {
                    Title = "Play/Pause",
                    SubTitle = $"{_itApp.CurrentTrack.Name} - {_itApp.CurrentTrack.Artist} {TimeSpan.FromSeconds(_itApp.PlayerPosition).ToString(@"mm\:ss")} / {_itApp.CurrentTrack.Time}",
                    IcoPath = "Images\\Itunes.png",  //relative path to your plugin directory
                    Action = e =>
                    {
                        _itApp.PlayPause();
                        return true;
                    }
                },
                new Result{
                    Title = "Next song",
                    SubTitle = "Agla Gaana",
                    IcoPath = "Images\\Itunes.png",
                    Action = e => {
                        _itApp.NextTrack();
                        if(_itApp.PlayerState == ITPlayerState.ITPlayerStateStopped)
                        {
                            _itApp.Play();
                        }
                        return false;
                    }
                },
                new Result{
                    Title = "Previous song",
                    SubTitle = "Pichla Gaana",
                    IcoPath = "Images\\Itunes.png",
                    Action = e => {
                        _itApp.PreviousTrack();
                        if(_itApp.PlayerState == ITPlayerState.ITPlayerStateStopped)
                        {
                            _itApp.Play();
                        }
                        return false;
                    }
                }
            };
            return results;
        }
    }
}
