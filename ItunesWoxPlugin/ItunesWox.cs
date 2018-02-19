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
            try
            {

                _itApp = new iTunesApp();
            }
            catch (Exception)
            {
                // TODO: Something to start the Itunes music player
                throw;
            }
        }

        public List<Result> Query(Query query)
        {
            if (string.IsNullOrWhiteSpace(query.Search))
            {
                return StandardMenu();
            }

            return new List<Result> {
                new Result{
                    Title = $"Search Result: {query.Search}",
                    SubTitle = "TODO",
                    IcoPath = "Images\\Itunes.png",
                    Action = e => {
                        return true;
                    }
                }
            };
        }

        private List<Result> StandardMenu()
        {
            List<Result> results = new List<Result>
            {
                new Result()
                {
                    Title = "Play/Pause",
                    SubTitle = _itApp.CurrentTrack.Name,
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
