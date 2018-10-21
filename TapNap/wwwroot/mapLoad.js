var map;
let changed = false;
var styleArray = [
    {
        "featureType": "all",
        "elementType": "labels.text.fill",
        "stylers": [
            {
                "color": "#7c93a3"
            },
            {
                "lightness": "-10"
            }
        ]
    },
    {
        "featureType": "administrative.country",
        "elementType": "geometry",
        "stylers": [
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "administrative.country",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "color": "#a0a4a5"
            }
        ]
    },
    {
        "featureType": "administrative.province",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "color": "#62838e"
            }
        ]
    },
    {
        "featureType": "landscape",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "color": "#dde3e3"
            }
        ]
    },
    {
        "featureType": "landscape.man_made",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "color": "#3f4a51"
            },
            {
                "weight": "0.30"
            }
        ]
    },
    {
        "featureType": "poi",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "simplified"
            }
        ]
    },
    {
        "featureType": "poi.attraction",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "poi.business",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "poi.government",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "poi.park",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "poi.place_of_worship",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "poi.school",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "poi.sports_complex",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "road",
        "elementType": "all",
        "stylers": [
            {
                "saturation": "-100"
            },
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "road",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "road.highway",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "color": "#bbcacf"
            }
        ]
    },
    {
        "featureType": "road.highway",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "lightness": "0"
            },
            {
                "color": "#bbcacf"
            },
            {
                "weight": "0.50"
            }
        ]
    },
    {
        "featureType": "road.highway",
        "elementType": "labels",
        "stylers": [
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "road.highway",
        "elementType": "labels.text",
        "stylers": [
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "road.highway.controlled_access",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "color": "#ffffff"
            }
        ]
    },
    {
        "featureType": "road.highway.controlled_access",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "color": "#a9b4b8"
            }
        ]
    },
    {
        "featureType": "road.arterial",
        "elementType": "labels.icon",
        "stylers": [
            {
                "invert_lightness": true
            },
            {
                "saturation": "-7"
            },
            {
                "lightness": "3"
            },
            {
                "gamma": "1.80"
            },
            {
                "weight": "0.01"
            }
        ]
    },
    {
        "featureType": "transit",
        "elementType": "all",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "water",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "color": "#a3c7df"
            }
        ]
    }
];

var citymap = {
  '1': {
    center: {lat: 30.2849, lng: -97.7241},
  },
  '2': {
    center: {lat: 30.3149, lng: -97.7741},
  },
  '3': {
    center: {lat: 30.2647, lng: -97.7441},
  },
  '4': {
    center: {lat: 30.2811, lng: -97.6941},
  },
  '5': {
    center: {lat: 30.3001, lng: -97.7382},
  },
};
var markers = [];
var infoBubbles = [];


function initMap() {
  map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: 30.2849, lng: -97.7341},
    zoom: 14,
    styles: styleArray,
    mapTypeControlOptions: {
      mapTypeIds: [],
    },
    fullscreenControl: false,
    streetViewControl: false,
    zoomControl: false,
  });

  //custom zoom controls
  let controlDiv = document.createElement('div');
  controlDiv.classList.add("map-control-panel");

  let zoomIn = document.createElement('img');
  zoomIn.style.width = '16px';
  zoomIn.style.height = '16px';
  zoomIn.src = "imageAssets/plus.svg";
  zoomIn.style.cursor = "pointer";
  //set css here for zoomIn
  google.maps.event.addDomListener(zoomIn, 'click', function() {
    map.setZoom(map.getZoom() + 1);
  })

  let separate = document.createElement('img');
  separate.src = "imageAssets/separate.svg";

  let zoomOut = document.createElement('img');
  zoomOut.style.width = '16px';
  zoomOut.style.height = '16px';
  zoomOut.src = "imageAssets/minus.svg";
  zoomOut.style.cursor = "pointer";
  //set css here for zoomOut
  google.maps.event.addDomListener(zoomOut, 'click', function() {
    map.setZoom(map.getZoom() - 1);
  })

  controlDiv.appendChild(zoomOut);
  controlDiv.appendChild(separate);
  controlDiv.appendChild(zoomIn);
  map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(controlDiv);

  // Top google searchbar
  let input = document.getElementById('searchbar-top');
  let searchBox = new google.maps.places.SearchBox(input);

  map.addListener('bounds_changed', function() {
    searchBox.setBounds(map.getBounds());
  });

  searchBox.addListener('places_changed', function() {
    var places = searchBox.getPlaces();

    if (places.length == 0) {
      return;
    }

    // For each place, get the icon, name and location.
    var bounds = new google.maps.LatLngBounds();
    places.forEach(function(place) {
      if (!place.geometry) {
        console.log("Returned place contains no geometry");
        return;
      }

      if (changed) {
        markers.pop().setMap(null);
      }
      // Create a marker for each place.
      markers.push(new google.maps.Marker({
        map: map,
        icon: {
          path: 'M256,0c-70.703,0-128,57.313-128,128c0,51.5,30.563,95.563,74.375,115.875L256,512l53.625-268.125 C353.438,223.563,384,179.5,384,128C384,57.313,326.688,0,256,0z M256,192c-35.344,0-64-28.656-64-64s28.656-64,64-64 s64,28.656,64,64S291.344,192,256,192z',
          fillOpacity: 1.0,
          fillColor: 'red',
          fillWeight: 1.0,
          strokeOpacity: 1.0,
          strokeColor: 'white',
          strokeWeight: 1.5,
          scale: 0.07,
        },
        title: place.name,
        position: place.geometry.location
      }));
      changed = true;

      if (place.geometry.viewport) {
        // Only geocodes have viewport.
        bounds.union(place.geometry.viewport);
      } else {
        bounds.extend(place.geometry.location);
      }
    });
    map.fitBounds(bounds);
    document.getElementById('searchbar-top').value = "";
    document.getElementById("listing-exit").parentElement.classList.remove("show-listing-information");
    document.getElementById('searchbar-top').blur();
  });

  // Mobile searcbar area
  let mobileInput = document.getElementById('searchbar-mobile');
  let mobileSearchBox = new google.maps.places.SearchBox(mobileInput);

  map.addListener('bounds_changed', function() {
    mobileSearchBox.setBounds(map.getBounds());
  });

  mobileSearchBox.addListener('places_changed', function() {
    var places = mobileSearchBox.getPlaces();

    if (places.length == 0) {
      return;
    }

    // For each place, get the icon, name and location.
    var bounds = new google.maps.LatLngBounds();
    places.forEach(function(place) {
      if (!place.geometry) {
        console.log("Returned place contains no geometry");
        return;
      }

      if (place.geometry.viewport) {
        // Only geocodes have viewport.
        bounds.union(place.geometry.viewport);
      } else {
        bounds.extend(place.geometry.location);
      }
    });
    map.fitBounds(bounds);
    document.getElementById('searchbar-mobile').value = "";
    document.getElementById('searchbar-mobile').blur();
  });

  // Set the markers for each available bed.
  // Add ID stuff to the addListener function
  for (let city in citymap) {

    let marker = new google.maps.Marker({
      map: map,
      position: new google.maps.LatLng(citymap[city].center.lat, citymap[city].center.lng),
      icon: {
        path: 'M256,0c-70.703,0-128,57.313-128,128c0,51.5,30.563,95.563,74.375,115.875L256,512l53.625-268.125 C353.438,223.563,384,179.5,384,128C384,57.313,326.688,0,256,0z M256,192c-35.344,0-64-28.656-64-64s28.656-64,64-64 s64,28.656,64,64S291.344,192,256,192z',
        fillOpacity: 1.0,
        fillColor: 'black',
        fillWeight: 1.0,
        strokeOpacity: 1.0,
        strokeColor: 'black',
        strokeWeight: 1.5,
        scale: 0.07,
      }
    });

    // When you click the marker
    marker.addListener('click', function() {
      //Reset other marker styles

      // Make a request, pull up additional information as needed
      document.getElementById("listing-exit").parentElement.classList.add("show-listing-information");

      // Pan map center to the current map
      map.panTo(marker.getPosition());
      // map.panBy(0, -500);
    });

    markers.push(marker);
  }

}
