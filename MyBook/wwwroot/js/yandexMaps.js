ymaps.ready(init);

function init(){
    var myMap = new ymaps.Map("map", {
        center: [55.76, 37.64],
        zoom: 13
    });

    myMap.geoObjects.add(new ymaps.Placemark([55.753048, 37.611111], {
        balloonContent: '<strong>Тут наш центр</strong>'
    }, {
        preset: 'islands#circleDotIcon',
        iconColor: 'yellow'
    }))
}