ymaps.ready(init);

async function init(){
    let myMap = new ymaps.Map("map", {
        center: [55.689547, 37.913226],
        zoom: 10
    });
    myCollection = new ymaps.GeoObjectCollection();
    $.ajax(
        {
            type: "GET",
            url:`/Home/GetBooksCenter`,
            success: function (data) {
                $.each(data,function(index,value){
                    console.log(value)
                    myCollection.add(new ymaps.Placemark(
                        [value.latitude, value.longitude], {
                            balloonContentBody: "Тут наш центр"
                        }
                    ));
                });
                myMap.geoObjects.add(myCollection);
                var mySearchControl = new ymaps.control.SearchControl({
                    options: {
                        provider: new CustomSearchProvider(data),
                        noPlacemark: true,
                        resultsPerPage: 5
                    }});
                myMap.controls
                    .add(mySearchControl, { float: 'right' });
            },
            error: function (data){
                alert("Что-то пошло не так при загрузке карты , повторите попытку позже.");
            }
        }
    )
}
function CustomSearchProvider(points) {
    this.points = points;
}
function showCenter(name){
    $.ajax(
        {
            type: "GET",
            url:`/Home/GetBookCenter?name=${name}`,
            success: function (data) {
                $.each(data,function(index,value){
                    console.log(value)
                    myMap.center = [value.latitude,value.longitude]
                })
            },
            error: function (data){
                alert("Что-то пошло не так при загрузке карты , повторите попытку позже.");
            }
        }
    )
}
CustomSearchProvider.prototype.geocode = function (request, options) {
    var deferred = new ymaps.vow.defer(),
        geoObjects = new ymaps.GeoObjectCollection(),
        // Сколько результатов нужно пропустить.
        offset = options.skip || 0,
        // Количество возвращаемых результатов.
        limit = options.results || 20;

    var points = [];
    // Ищем в свойстве text каждого элемента массива.
    for (var i = 0, l = this.points.length; i < l; i++) {
        var point = this.points[i];
        if (point.address.toLowerCase().indexOf(request.toLowerCase()) != -1) {
            points.push(point);
        }
    }
    // При формировании ответа можно учитывать offset и limit.
    points = points.splice(offset, limit);
    // Добавляем точки в результирующую коллекцию.
    for (var i = 0, l = points.length; i < l; i++) {
        var point = points[i],
            coords = [point.latitude,point.longitude],
            text = point.address;

        geoObjects.add(new ymaps.Placemark(coords, {
            name: text + ' name',
            description: text + ' description',
            balloonContentBody: '<p>' + text + '</p>',
            boundedBy: [coords, coords]
        }));
    }

    deferred.resolve({
        // Геообъекты поисковой выдачи.
        geoObjects: geoObjects,
        // Метаинформация ответа.
        metaData: {
            geocoder: {
                // Строка обработанного запроса.
                request: request,
                // Количество найденных результатов.
                found: geoObjects.getLength(),
                // Количество возвращенных результатов.
                results: limit,
                // Количество пропущенных результатов.
                skip: offset
            }
        }
    });

    // Возвращаем объект-обещание.
    return deferred.promise();
};

