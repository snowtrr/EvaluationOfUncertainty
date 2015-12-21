

using System;

namespace CreateGraphics
{
    using System.Runtime.Remoting.Messaging;
    using CreateGraphics.BL ;

    public class MainPresenter
    {
        private readonly IGraphic _graphic;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;

        public MainPresenter(IGraphic graphic, IFileManager manager, IMessageService messageService)
        {
            _manager = manager;
            _messageService = messageService;
            _graphic = graphic;

            _graphic.FileOpenClick += _graphic_FileOpenClick;
        }

        private void _graphic_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _graphic.FilePath;
                bool isExist = _manager.IsExist(filePath);

                if (!isExist)
                {
                    _messageService.ShowExclamation("File is not exist");
                }

                _manager.ReadContent(filePath);//прямота исполнения??
                
                _graphic.ContentX = _manager.GetContentX;
                _graphic.ContentY = _manager.GetContentY;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}