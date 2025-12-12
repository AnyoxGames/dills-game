13
3835405795329
404943451517909 1761863307893812200
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -12.0089950561523438,
    "Y": -10.3255624771118164
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404941592186212:1761863307460586800",
  "next_sibling": "404946241489444:1761863308543878300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404943451763396:1761863307893868500",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404943451901254:1761863307893900600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404943451763396:1761863307893868500",
    "DefaultRenderer": "404943451953069:1761863307893912600",
    "DepletedRenderer": "404943451933719:1761863307893908100"
  }
},
{
  "cid": 5,
  "aoid": "404943451913466:1761863307893903400",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
