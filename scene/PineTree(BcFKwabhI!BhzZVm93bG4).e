13
4157528342529
404975426058312 1761863315343913400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 4.2392282485961914,
    "Y": -11.1379728317260742
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404974352571181:1761863315093789700",
  "next_sibling": "404976569700760:1761863315610383100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404975426454213:1761863315344004500",
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
  "aoid": "404975426605616:1761863315344039800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404975426454213:1761863315344004500",
    "DefaultRenderer": "404975426841365:1761863315344094700",
    "DepletedRenderer": "404975426801762:1761863315344085900"
  }
},
{
  "cid": 5,
  "aoid": "404975426627847:1761863315344045000",
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
