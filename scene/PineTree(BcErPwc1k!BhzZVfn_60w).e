13
3813930958849
404941592186212 1761863307460586800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -13.6551961898803711,
    "Y": -10.6034917831420898
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404938659387424:1761863306777241200",
  "next_sibling": "404943451517909:1761863307893812200",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404941592514603:1761863307460661600",
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
  "aoid": "404941592635304:1761863307460689700",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404941592514603:1761863307460661600",
    "DefaultRenderer": "404941592688409:1761863307460702100",
    "DepletedRenderer": "404941592670263:1761863307460697900"
  }
},
{
  "cid": 5,
  "aoid": "404941592648462:1761863307460692800",
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
