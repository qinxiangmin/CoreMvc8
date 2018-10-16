(function() {
    $(function() {
        //你的代码写在这里
      //  alert("ok  javascript");
        var _booksService = abp.services.app.book;
        var _$modal = $('#BookCreateModal');
        var _$form = _$modal.find('form');
        $('.delete-book').click(function () {
            var userId = $(this).attr("data-user-id");
            var bookName = $(this).attr('data-user-name');

            deleteBook(userId, bookName);
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var book = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            book.roleNames = [];
            var _$roleCheckboxes = $("input[name='role']:checked");
            if (_$roleCheckboxes) {
                for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                    var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                    book.roleNames.push(_$roleCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);

            _booksService.create(book).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        $('.edit-book').click(function (e) {

            var bookId = $(this).attr("data-user-id");
           
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Books/Details?Id=' + bookId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#BookEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });


        function deleteBook(userId, bookName) {
            abp.message.confirm(
                abp.utils.formatString("你要删除此记录" + bookName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _booksService.delete({
                            id: userId
                        }).done(function () {

                            abp.message.success('删除成功', bookName + '已经被彻底删除');
                            refreshUserList();
                        });
                    }
                }
            );
        }

        function refreshUserList() {
            location.reload(true); //重新加载页面以查看新书!
        }
     
    });
})();