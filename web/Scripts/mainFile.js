Gra = function () {
    var urlShowAll = localStorage.getItem("api-showAll-url");
    var urlshowById = localStorage.getItem("api-showById-url");
    var urlDeleteById = localStorage.getItem("api-deleteById-url");
    var urlAdd = localStorage.getItem("api-add-url");
    
    this.showAll = function () {
        return $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: urlShowAll,
            success: function (msg) {
                var string = "";

                msg = $.parseJSON(msg)

                $.each(msg, function (key, value) {
                     string = string + "Ksiazka o id: " + value.id + "\n" + "tytul: " + value.tytul + " cena: " + value.cena;
                     string = string + "\n\n"
                 });
                
                $('#textArea').val(string);
            }
        })
    }

    this.getById = function (ind) {
        return $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: urlshowById,
            dataType: 'json',
            data: {
                ind: ind
            },
            success: function (msg) {
                console.log(msg)
                var string = "";
                if (msg[0] == null) {
                    string = "404";
                } else {
                    $.each(msg, function (key, value) {
                        string = string + "Ksiazka o id: " + value.id + "\n" + "tytul: " + value.tytul + " cena: " + value.cena;
                        string = string + "\n\n"
                    });
                }
                $('#textArea').val(string);
            },
            error: function (request, status, error) {
                console.log(status);
                console.log(error);
                console.log(request);
            }
        })
    }

    this.deleteById = function (ind) {
        return $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: urlDeleteById,
            dataType: 'json',
            data: {
                ind: ind
            },
            success: function (msg) {
                console.log(msg)
                $('#textArea').val(msg.odpowiedz);
            },
            error: function (request, status, error) {
                console.log(status);
                console.log(error);
                console.log(request);
            }
        })
    }
  
    this.add = function (tytul, cena) {
        return $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: urlAdd,
            dataType: 'json',
            data: {
                tytul: tytul,
                cena: cena
            },
            success: function (msg) {
                console.log(msg)
                $('#textArea').val(msg.odpowiedz);
            },
            error: function (request, status, error) {
                console.log(status);
                console.log(error);
                console.log(request);
            }
        })
    }
}

var game = new Gra();

window.onload = function () {
    
    $('#showAll').click(function () {
        game.showAll();
    })

    $('#buttonShowById').click(function () {
        game.getById($('#showById').val());
    })

    $('#buttonDeleteById').click(function () {
        game.deleteById($('#showById').val());
    })
    
    $('#buttonAdd').click(function () {
        console.log()
        game.add($('#title').val(), $('#cena').val());
    })
}
