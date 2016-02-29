# dotnetserverhealthinformer

This is to provide a simple json responder on a windows iis box to display consumalbe information on the servers state and services

This is an example expected result
`[
  {
    "serverInfo": [
      {
        "osVersion": "64 Bit Operating System",
        "SystemDirectory": "C:\\windows\\system32",
        "ProcessorCount": 2,
        "SystemPageSize": 4096,
        "Version": null
      }
    ]
  },
  {
    "serviceInfo": [
      {
        "zabbixService": "service not installed",
        "newrelicService": "service not installed",
        "splunkService": "service not installed",
        "wasService": "Running",
        "w3svcService": "Running"
      }
    ]
  },
  {
    "connectiondata": [
      {
        "name": null
      },
      {
        "Upgrade-Insecure-Requests": "1"
      },
      {
        "Cache-Control": "max-age=0"
      },
      {
        "Connection": "keep-alive"
      },
      {
        "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
      },
      {
        "Accept-Encoding": "gzip, deflate, sdch"
      },
      {
        "Accept-Language": "en-US,en;q=0.8"
      },
      {
        "Authorization": "Negotiate oXcwdaADCgEBoloEWE5UTE1TU1AAAwAAAAAAAABYAAAAAAAAAFgAAAAAAAAAWAAAAAAAAABYAAAAAAAAAFgAAAAAAAAAWAAAABXCiOIGA4AlAAAAD+/aIG//YTeyQCDjG4VGn7GjEgQQAQAAAO7BTiELhsTvAAAAAA=="
      },
      {
        "Cookie": "arp_scroll_position=0"
      },
      {
        "Host": "localhost:1034"
      },
      {
        "User-Agent": "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36"
      }
    ]
  },
  {
    "iisconfiguration": [
      {
        "site": "Default Web Site",
        "id": 1,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 3,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudo",
        "id": 2,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 3,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "test",
        "id": 5,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/SolarWorks",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/SolarWorks-Api",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/GSA",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/ApprovalPortal/WebApi",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/ApprovalPortal",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/JCO",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudu_service_testies",
        "id": 3,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/_app",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudu_testies",
        "id": 4,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudu_service_whysoslow",
        "id": 6,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/_app",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudu_whysoslow",
        "id": 7,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudu_service_try2anon",
        "id": 8,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          },
          {
            "vir": "/_app",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      },
      {
        "site": "kudu_try2anon",
        "id": 9,
        "logFormat": 2,
        "directory": "%SystemDrive%\\inetpub\\logs\\LogFiles",
        "state": 1,
        "applications": [
          {
            "vir": "/",
            "virtual dirs": [
              "/"
            ]
          }
        ]
      }
    ]
  }
]`
